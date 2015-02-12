using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;

public class NameGenerator {

	/**
	 * Class that represents a pairing between a generated word and its score (how closely it resembles normal English words)
	 */
	public class GeneratedWordValue {
		public string word;
		public double score;
		public GeneratedWordValue(string word) {
			this.word = word;
			NameGenerator ng = new NameGenerator(0);
			this.score = ng.evaluateWordBasedOnDigrams(word);
		}
	} 

	//Number of planets to create
	int numberToGenerate;

	System.Random random = new System.Random();

	//Frequency of digrams appearing in the English language
	Dictionary<string, double> digramProbabilities = DigramProbabilities.getProbabilities();

	//Digrams to prevent from appearing at the start of the generation
	string[] disallowedForStart = new string[] {
		"bf","cb","cc","ce","ck","cw","df","dg","dl","dq","dt","ej","ff","gg","gh","hk","hl","ll","lk","lm","mp","mr","mz","nd","nk","nn","ns","nt","oo","rc","rd","rg","rk","rl","rm","rn","rp","rr","rs","rt","rv","rw","rx","sj","sr","ss","tc","tl","ts","tt","ug","vb","xc","xp","xs","xt","yc","yj","yr","yt","yy","zh","zk","zr","zs","zz"
	};

	//Groups of letters that are possible to appear, but that shouldn"t finish off a name
	string[] wordsToAvoidAtEnd = new string[] {
		"dri","li","sc","ixi","dr","ae","dla","bhe","bf","edl","kr","xo","vei","aiv","gr","sv","fha","sci","dl","dr","vb","nn","blu","eex","rrd","ji","gg","eew","whe","ecl","itl","dg","cb", "rw", "cr","fr","kl"
	};

	/**
	 * How frequently particular digrams appears in the English language
	 * @type {Dictionary}
	 */
	Dictionary<string, List<WordSequences.DigramValue>> digramWordFreq = WordSequences.getSequences();

	/**
	 * Creates a new name generator
	 * @param int - the amount of planets we want to generate
	 */
	public NameGenerator(int numberOfPlanets) {
		numberToGenerate = numberOfPlanets;		
	}

	private Dictionary<string, List<WordSequences.DigramValue>> sortWordFreq(Dictionary<string, List<WordSequences.DigramValue>> wordFreq) {
		Dictionary<string, List<WordSequences.DigramValue>> newWordFreq = new Dictionary<string, List<WordSequences.DigramValue>>();
		foreach (KeyValuePair<string, List<WordSequences.DigramValue>> pair in wordFreq) {
			//Sort the values to their priority
			List<WordSequences.DigramValue> sorted = new List<WordSequences.DigramValue>();
			sorted.AddRange(pair.Value.OrderByDescending(v=>v.frequency));

			//Calculate new probabilities that sum to one
			double total = 0;
			List<double> newWeightings = new List<double>();
			for (int i=0; i<sorted.Count; i++) {
				double randomValue = random.NextDouble();
				total += randomValue;
				newWeightings.Add(randomValue);
			}

			//Multiple them by the recripricol of the total to ensure that they all sum to one
			double adjustingFactor = (1.0 / total);
			List<double> adjustedWeightings = new List<double>();
			foreach (double weighting in newWeightings) {
				adjustedWeightings.Add(weighting * adjustingFactor);
			}

			adjustedWeightings.Sort();
			adjustedWeightings.Reverse();

			//Combine the ordering of the sorted digrams with the new weightings 
			List<WordSequences.DigramValue> combinedNewWeightsWithDigrams = new List<WordSequences.DigramValue>();
			for(int i=0; i<sorted.Count; i++) {
				WordSequences.DigramValue currentDigram = sorted.ElementAt(i);
				double newWeighting = adjustedWeightings.ElementAt(i);
				WordSequences.DigramValue newDigram = new WordSequences.DigramValue(currentDigram.digram, newWeighting);
				combinedNewWeightsWithDigrams.Add(newDigram);
			}

			newWordFreq.Add(pair.Key, combinedNewWeightsWithDigrams);
		}
		return newWordFreq;
	}

	/**
	 * Checks the end of the word for certain phrases to avoid and trims it off
	 * If the word becomes too small, we kickoff another generation with the remaining word as a seed
	 * @param  string - the initial generated word we are checking
	 * @param  int - the max length that a string can be (used in regenerating the word)
	 * @return string - a sanitized randomly generated word
	 */
	private string checkEndWord(string generatedWord, int maxLength) {
		bool found = false;
		foreach (string word in wordsToAvoidAtEnd) {
			if (generatedWord.EndsWith(word)) {
				int indexOfBadEnding = generatedWord.LastIndexOf(word);

				if (indexOfBadEnding > 0) {
					generatedWord = generatedWord.Substring(0, indexOfBadEnding);
					found = true;
					if (generatedWord.Length < 4) {
						generatedWord = generate(generatedWord, maxLength);
					}
				}
			}
		}
		if (found) {
			generatedWord = checkEndWord(generatedWord, maxLength);
		}
		return generatedWord;
	}

	/**
	 * Generates a word based off an initial value, and a maximum length of characters
	 * @param  string - the initial string we want to use as a basis
	 * @param  int - The maximum length of a particular word
	 * @return string - a newly generated random word
	 */
	private string generate(string initialSeed, int maxLength) {
		if (initialSeed.Length == 0) {
			initialSeed = generateSeed();
		}
		while (initialSeed.Length < maxLength) {
			if (initialSeed.Length > 4 && random.NextDouble() < .25) {
				break;
			} else {
				//Find last two characters of string
				string lastTwoChars = initialSeed.Length > 2 ? initialSeed.Substring(initialSeed.Length - 2, 2) : initialSeed;

				//Get possible digrams
				List<WordSequences.DigramValue> output;
				if (digramWordFreq.TryGetValue(lastTwoChars, out output)) {
					initialSeed += getRandomDigram(output);
				} else {
					break;
				}
			}
		}
		initialSeed = checkEndWord(initialSeed, maxLength);
		return initialSeed;
	}

	/**
	 * Creates a random starting point to base our word off of
	 * @return string - A digram to generate a word from
	 */
	private string generateSeed() {
		List<string> keyList = new List<string>(digramWordFreq.Keys);
		string randomKey = keyList[random.Next(keyList.Count)];
		while (disallowedForStart.Contains(randomKey)) {
			randomKey = keyList[random.Next(keyList.Count)];
		}
		return randomKey;
	}

	/**
	 * Finds a random digram from the list of available diagrams
	 * @param  A list of digrams that we can choose form
	 * @return string - the following character of a digram (i.e. returns I from KI or A from PA)
	 */
	private string getRandomDigram(List<WordSequences.DigramValue> listOfPossibleDigrams) {
		double probability = random.NextDouble();
		foreach (WordSequences.DigramValue digramVal in listOfPossibleDigrams) {
			probability -= digramVal.frequency;
			if (probability <= 0) {
				return digramVal.digram.Substring(1,1); 
			}
		}
		//Fetch the last element in the case of failure
		return listOfPossibleDigrams.ElementAt(listOfPossibleDigrams.Count-1).digram.Substring(1,1);
	}

	/**
	 * Takes the first letter of a string and converts its to upper case
	 * e.g. test becomes Test
	 * @param  string - the string we want to uppercase
	 * @return string - an uppercased version of the string 
	 */
	private string uppercaseFirst(string s) {
		if (string.IsNullOrEmpty(s))
		{
		    return string.Empty;
		}
		char[] a = s.ToCharArray();
		a[0] = char.ToUpper(a[0]);
		return new string(a);
	}

	/**
	 * Takes a list of digram probablities and computes a score for a particular word
	 * to see how well it fits into the English language (higher score is better)
	 * @param  string - the word we want to evaluate
	 * @return double - the score of how similar the word is to other English language words
	 */
	private double evaluateWordBasedOnDigrams(string word) {
		double total = 1.0;
		for (int i=1; i<word.Length; i++) {
			string digram = "" + word[i-1] + word[i];
			total *= digramProbabilities[digram.ToUpper()];
		}
		// Normalize score by word length
		total /= word.Length;
		return total;
	}

	/**
	 * Generates a random planet name (by default 8 characters)
	 * @return string - a newly random generated word
	 */
	public string generatePlanetName() {
		return generate("", 8);
	}

	/**
	 * Generates a (numberToGenerate) amount of random names, and sorts them by their relative score
	 * @return A sorted list of randomly generated names
	 */
	private List<GeneratedWordValue> generateNamesSortedByScore() {
		List<GeneratedWordValue> generatedNamesAndScores = new List<GeneratedWordValue>();
		for (int i=0; i<numberToGenerate; i++) {
			generatedNamesAndScores.Add(new GeneratedWordValue(generate("", 8)));
		}

		// Order by score descending
		List<GeneratedWordValue> generatedNamesAndScoresSorted = new List<GeneratedWordValue>();
		generatedNamesAndScoresSorted.AddRange(generatedNamesAndScores.OrderByDescending(w=>w.score));

		return generatedNamesAndScoresSorted;
	}
	
	/**
	 * Generates a set number of planet names, sorted them by score, and returns a list ordered by the words most similar to English
	 * @see generatePlanetNames()
	 * @return Queue - queue of randomly generated names 
	 */
	public Queue<string> generatePlanetNamesAsQueue() {
		List<GeneratedWordValue> namesSortedByScore = generateNamesSortedByScore();
		Queue<string> sorted = new Queue<string>();
		string previousWord = "";
		foreach (GeneratedWordValue gwv in namesSortedByScore) {
			// Ensure no duplicates for planet names in generated list (they should be sorted next to each other by scoring)
			if (gwv.word != previousWord && gwv.word.Length > 4) {
				previousWord = gwv.word;
				sorted.Enqueue(uppercaseFirst(gwv.word));
			}
		}
		return sorted;
	}

	/**
	 * Generates a set number of planet names, sorted them by score, and returns a list ordered by the words most similar to English
	 * Removes duplicates and words that happen to be under four characters
	 * @return List - list of randomly generated names
	 */
	public List<string> generatePlanetNames() {
		List<GeneratedWordValue> namesSortedByScore = generateNamesSortedByScore();

		List<string> sorted = new List<string>();
		string previousWord = "";
		foreach (GeneratedWordValue gwv in namesSortedByScore) {
			// Ensure no duplicates for planet names in generated list (they should be sorted next to each other by scoring)
			if (gwv.word != previousWord && gwv.word.Length > 4) {
				previousWord = gwv.word;
				sorted.Add(uppercaseFirst(gwv.word));
			}
		}
		return sorted;
	}
}
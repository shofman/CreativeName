using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;

public class NameGenerator {

	//Representation of digrams and their respective frequency
	public class DigramValue {
		public string digram;
		public double frequency;
		/**
		 * @var digramValue - Two letter digram to represent
		 * @var frequency - How often the digram should appear
		 */
		public DigramValue(string digramValue, double frequency) {
			this.digram = digramValue;
			this.frequency = frequency;
		}
	}

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
	Dictionary<string, double> digramProbabilities = new Dictionary<string, double>() {
		{"AA", 0.003},
	    {"BA", 0.146},
	    {"CA", 0.538},
	    {"DA", 0.151},
	    {"EA", 0.688},
	    {"FA", 0.164},
	    {"GA", 0.148},
	    {"HA", 0.926},
	    {"IA", 0.286},
	    {"JA", 0.026},
	    {"KA", 0.017},
	    {"LA", 0.528},
	    {"MA", 0.565},
	    {"NA", 0.347},
	    {"OA", 0.057},
	    {"PA", 0.324},
	    {"QA", 0.001},
	    {"RA", 0.686},
	    {"SA", 0.218},
	    {"TA", 0.530},
	    {"UA", 0.136},
	    {"VA", 0.140},
	    {"WA", 0.385},
	    {"XA", 0.030},
	    {"YA", 0.016},
	    {"ZA", 0.025},

	    {"AB", 0.230},
	    {"BB", 0.011},
	    {"CB", 0.001},
	    {"DB", 0.003},
	    {"EB", 0.027},
	    {"HB", 0.004},
	    {"IB", 0.099},
	    {"KB", 0.001},
	    {"LB", 0.007},
	    {"MB", 0.090},
	    {"NB", 0.004},
	    {"OB", 0.097},
	    {"PB", 0.001},
	    {"RB", 0.027},
	    {"SB", 0.008},
	    {"TB", 0.003},
	    {"UB", 0.089},
	    {"VB", 0.001},
	    {"WB", 0.001},
	    {"YB", 0.004},
	    {"AC", 0.448},
	    {"BC", 0.002},
	    {"CC", 0.083},
	    {"DC", 0.003},
	    {"EC", 0.477},
	    {"FC", 0.001},
	    {"HC", 0.001},
	    {"IC", 0.699},
	    {"LC", 0.012},
	    {"MC", 0.004},
	    {"NC", 0.416},
	    {"OC", 0.166},
	    {"PC", 0.001},
	    {"RC", 0.121},
	    {"SC", 0.155},
	    {"TC", 0.026},
	    {"UC", 0.188},
	    {"WC", 0.001},
	    {"XC", 0.026},
	    {"YC", 0.014},

	    {"AD", 0.368},
	    {"BD", 0.002},
	    {"CD", 0.002},
	    {"DD", 0.043},
	    {"ED", 1.168},
	    {"GD", 0.003},
	    {"HD", 0.003},
	    {"ID", 0.296},
	    {"KD", 0.001},
	    {"LD", 0.253},
	    {"MD", 0.001},
	    {"ND", 1.352},
	    {"OD", 0.195},
	    {"PD", 0.001},
	    {"RD", 0.189},
	    {"SD", 0.005},
	    {"TD", 0.001},
	    {"UD", 0.091},
	    {"WD", 0.004},
	    {"YD", 0.007},

	    {"AE", 0.012},
	    {"BE", 0.576},
	    {"CE", 0.651},
	    {"DE", 0.765},
	    {"EE", 0.378},
	    {"FE", 0.237},
	    {"GE", 0.385},
	    {"HE", 3.075},
	    {"IE", 0.385},
	    {"JE", 0.052},
	    {"KE", 0.214},
	    {"LE", 0.829},
	    {"ME", 0.793},
	    {"NE", 0.692},
	    {"OE", 0.039},
	    {"PE", 0.478},
	    {"RE", 1.854},
	    {"SE", 0.932},
	    {"TE", 1.205},
	    {"UE", 0.147},
	    {"VE", 0.825},
	    {"WE", 0.361},
	    {"XE", 0.022},
	    {"YE", 0.093},
	    {"ZE", 0.050},

	    {"AF", 0.074},
	    {"BF", 0.001},
	    {"CF", 0.001},
	    {"DF", 0.003},
	    {"EF", 0.163},
	    {"FF", 0.146},
	    {"GF", 0.001},
	    {"HF", 0.002},
	    {"IF", 0.203},
	    {"KF", 0.002},
	    {"LF", 0.053},
	    {"MF", 0.004},
	    {"NF", 0.067},
	    {"OF", 1.175},
	    {"PF", 0.001},
	    {"RF", 0.032},
	    {"SF", 0.017},
	    {"TF", 0.006},
	    {"UF", 0.019},
	    {"WF", 0.002},
	    {"XF", 0.002},
	    {"YF", 0.001},

	    {"AG", 0.205},
	    {"CG", 0.001},
	    {"DG", 0.031},
	    {"EG", 0.120},
	    {"FG", 0.001},
	    {"GG", 0.025},
	    {"IG", 0.255},
	    {"KG", 0.003},
	    {"LG", 0.006},
	    {"MG", 0.001},
	    {"NG", 0.953},
	    {"OG", 0.094},
	    {"RG", 0.100},
	    {"SG", 0.002},
	    {"TG", 0.002},
	    {"UG", 0.128},
	    {"YG", 0.003},

	    {"AH", 0.014},
	    {"BH", 0.001},
	    {"CH", 0.598},
	    {"DH", 0.005},
	    {"EH", 0.026},
	    {"FH", 0.001},
	    {"GH", 0.228},
	    {"HH", 0.001},
	    {"IH", 0.002},
	    {"KH", 0.003},
	    {"LH", 0.002},
	    {"MH", 0.001},
	    {"NH", 0.011},
	    {"OH", 0.021},
	    {"PH", 0.094},
	    {"RH", 0.015},
	    {"SH", 0.315},
	    {"TH", 3.556},
	    {"UH", 0.001},
	    {"VH", 0.001},
	    {"WH", 0.379},
	    {"XH", 0.004},
	    {"YH", 0.001},
	    {"ZH", 0.001},

	    {"AI", 0.316},
	    {"BI", 0.107},
	    {"CI", 0.281},
	    {"DI", 0.493},
	    {"EI", 0.183},
	    {"FI", 0.285},
	    {"GI", 0.152},
	    {"HI", 0.763},
	    {"II", 0.023},
	    {"JI", 0.003},
	    {"KI", 0.098},
	    {"LI", 0.624},
	    {"MI", 0.318},
	    {"NI", 0.339},
	    {"OI", 0.088},
	    {"PI", 0.123},
	    {"RI", 0.728},
	    {"SI", 0.550},
	    {"TI", 1.343},
	    {"UI", 0.101},
	    {"VI", 0.270},
	    {"WI", 0.374},
	    {"XI", 0.039},
	    {"YI", 0.029},
	    {"ZI", 0.012},

	    {"AJ", 0.012},
	    {"BJ", 0.023},
	    {"DJ", 0.005},
	    {"EJ", 0.005},
	    {"IJ", 0.001},
	    {"NJ", 0.011},
	    {"OJ", 0.007},
	    {"RJ", 0.001},
	    {"SJ", 0.001},
	    {"UJ", 0.001},
	    {"VJ", 0.001},
	    {"YJ", 0.001},

	    {"AK", 0.105},
	    {"CK", 0.118},
	    {"EK", 0.016},
	    {"HK", 0.001},
	    {"IK", 0.043},
	    {"LK", 0.020},
	    {"NK", 0.052},
	    {"OK", 0.064},
	    {"PK", 0.001},
	    {"RK", 0.097},
	    {"SK", 0.039},
	    {"UK", 0.005},
	    {"WK", 0.001},
	    {"ZK", 0.001},

	    {"AL", 1.087},
	    {"BL", 0.233},
	    {"CL", 0.149},
	    {"DL", 0.032},
	    {"EL", 0.530},
	    {"FL", 0.065},
	    {"GL", 0.061},
	    {"HL", 0.013},
	    {"IL", 0.432},
	    {"KL", 0.011},
	    {"LL", 0.577},
	    {"ML", 0.005},
	    {"NL", 0.064},
	    {"OL", 0.365},
	    {"PL", 0.263},
	    {"RL", 0.086},
	    {"SL", 0.056},
	    {"TL", 0.098},
	    {"UL", 0.346},
	    {"VL", 0.001},
	    {"WL", 0.015},
	    {"XL", 0.001},
	    {"YL", 0.015},
	    {"ZL", 0.001},

	    {"AM", 0.285},
	    {"BM", 0.003},
	    {"CM", 0.003},
	    {"DM", 0.018},
	    {"EM", 0.374},
	    {"FM", 0.001},
	    {"GM", 0.010},
	    {"HM", 0.013},
	    {"IM", 0.318},
	    {"KM", 0.002},
	    {"LM", 0.023},
	    {"MM", 0.096},
	    {"NM", 0.028},
	    {"OM", 0.546},
	    {"PM", 0.016},
	    {"RM", 0.175},
	    {"SM", 0.065},
	    {"TM", 0.026},
	    {"UM", 0.138},
	    {"WM", 0.001},
	    {"YM", 0.024},

	    {"AN", 1.985},
	    {"BN", 0.002},
	    {"CN", 0.001},
	    {"DN", 0.008},
	    {"EN", 1.454},
	    {"GN", 0.066},
	    {"HN", 0.026},
	    {"IN", 2.433},
	    {"KN", 0.051},
	    {"LN", 0.006},
	    {"MN", 0.009},
	    {"NN", 0.073},
	    {"ON", 1.758},
	    {"PN", 0.001},
	    {"RN", 0.160},
	    {"SN", 0.009},
	    {"TN", 0.010},
	    {"UN", 0.394},
	    {"WN", 0.079},
	    {"YN", 0.013},

	    {"AO", 0.005},
	    {"BO", 0.195},
	    {"CO", 0.794},
	    {"DO", 0.188},
	    {"EO", 0.073},
	    {"FO", 0.488},
	    {"GO", 0.132},
	    {"HO", 0.485},
	    {"IO", 0.835},
	    {"JO", 0.054},
	    {"KO", 0.006},
	    {"LO", 0.387},
	    {"MO", 0.337},
	    {"NO", 0.465},
	    {"OO", 0.210},
	    {"PO", 0.361},
	    {"RO", 0.727},
	    {"SO", 0.398},
	    {"TO", 1.041},
	    {"UO", 0.011},
	    {"VO", 0.071},
	    {"WO", 0.222},
	    {"XO", 0.003},
	    {"YO", 0.150},
	    {"ZO", 0.007},

	    {"AP", 0.203},
	    {"BP", 0.001},
	    {"CP", 0.001},
	    {"DP", 0.002},
	    {"EP", 0.172},
	    {"HP", 0.001},
	    {"IP", 0.089},
	    {"KP", 0.001},
	    {"LP", 0.019},
	    {"MP", 0.239},
	    {"NP", 0.006},
	    {"OP", 0.224},
	    {"PP", 0.137},
	    {"RP", 0.042},
	    {"SP", 0.191},
	    {"TP", 0.004},
	    {"UP", 0.136},
	    {"WP", 0.001},
	    {"XP", 0.067},
	    {"YP", 0.025},

	    {"AQ", 0.002},
	    {"CQ", 0.005},
	    {"DQ", 0.001},
	    {"EQ", 0.057},
	    {"IQ", 0.011},
	    {"NQ", 0.006},
	    {"OQ", 0.001},
	    {"RQ", 0.001},
	    {"SQ", 0.007},

	    {"AR", 1.075},
	    {"BR", 0.112},
	    {"CR", 0.149},
	    {"DR", 0.085},
	    {"ER", 2.048},
	    {"FR", 0.213},
	    {"GR", 0.197},
	    {"HR", 0.084},
	    {"IR", 0.315},
	    {"KR", 0.003},
	    {"LR", 0.010},
	    {"MR", 0.003},
	    {"NR", 0.009},
	    {"OR", 1.277},
	    {"PR", 0.474},
	    {"RR", 0.121},
	    {"SR", 0.006},
	    {"TR", 0.426},
	    {"UR", 0.543},
	    {"VR", 0.001},
	    {"WR", 0.031},
	    {"YR", 0.008},
	    {"ZR", 0.001},

	    {"AS", 0.871},
	    {"BS", 0.046},
	    {"CS", 0.023},
	    {"DS", 0.126},
	    {"ES", 1.339},
	    {"FS", 0.006},
	    {"GS", 0.051},
	    {"HS", 0.015},
	    {"IS", 1.128},
	    {"KS", 0.048},
	    {"LS", 0.142},
	    {"MS", 0.093},
	    {"NS", 0.509},
	    {"OS", 0.290},
	    {"PS", 0.055},
	    {"RS", 0.397},
	    {"SS", 0.405},
	    {"TS", 0.337},
	    {"US", 0.454},
	    {"VS", 0.001},
	    {"WS", 0.035},
	    {"XS", 0.001},
	    {"YS", 0.097},
	    {"ZS", 0.001},

	    {"AT", 1.487},
	    {"BT", 0.017},
	    {"CT", 0.461},
	    {"DT", 0.003},
	    {"ET", 0.413},
	    {"FT", 0.082},
	    {"GT", 0.015},
	    {"HT", 0.130},
	    {"IT", 1.123},
	    {"KT", 0.001},
	    {"LT", 0.124},
	    {"MT", 0.001},
	    {"NT", 1.041},
	    {"OT", 0.442},
	    {"PT", 0.106},
	    {"RT", 0.362},
	    {"ST", 1.053},
	    {"TT", 0.171},
	    {"UT", 0.405},
	    {"WT", 0.007},
	    {"XT", 0.047},
	    {"YT", 0.017},

	    {"AU", 0.119},
	    {"BU", 0.185},
	    {"CU", 0.163},
	    {"DU", 0.148},
	    {"EU", 0.031},
	    {"FU", 0.096},
	    {"GU", 0.086},
	    {"HU", 0.074},
	    {"IU", 0.017},
	    {"JU", 0.059},
	    {"KU", 0.003},
	    {"LU", 0.135},
	    {"MU", 0.115},
	    {"NU", 0.079},
	    {"OU", 0.870},
	    {"PU", 0.105},
	    {"QU", 0.148},
	    {"RU", 0.128},
	    {"SU", 0.311},
	    {"TU", 0.255},
	    {"UU", 0.001},
	    {"VU", 0.002},
	    {"WU", 0.001},
	    {"XU", 0.005},
	    {"YU", 0.001},
	    {"ZU", 0.002},

	    {"AV", 0.205},
	    {"BV", 0.004},
	    {"DV", 0.019},
	    {"EV", 0.255},
	    {"IV", 0.288},
	    {"KV", 0.001},
	    {"LV", 0.035},
	    {"NV", 0.052},
	    {"OV", 0.178},
	    {"RV", 0.069},
	    {"SV", 0.001},
	    {"TV", 0.001},
	    {"UV", 0.003},

	    {"AW", 0.060},
	    {"CW", 0.001},
	    {"DW", 0.008},
	    {"EW", 0.117},
	    {"GW", 0.001},
	    {"HW", 0.005},
	    {"IW", 0.001},
	    {"KW", 0.002},
	    {"LW", 0.013},
	    {"MW", 0.001},
	    {"NW", 0.006},
	    {"OW", 0.330},
	    {"PW", 0.001},
	    {"RW", 0.013},
	    {"SW", 0.024},
	    {"TW", 0.082},

	    {"AX", 0.019},
	    {"EX", 0.214},
	    {"IX", 0.022},
	    {"NX", 0.003},
	    {"OX", 0.019},
	    {"RX", 0.001},
	    {"UX", 0.004},
	    {"XX", 0.003},

	    {"AY", 0.217},
	    {"BY", 0.176},
	    {"CY", 0.042},
	    {"DY", 0.050},
	    {"EY", 0.144},
	    {"FY", 0.009},
	    {"GY", 0.026},
	    {"HY", 0.050},
	    {"KY", 0.006},
	    {"LY", 0.425},
	    {"MY", 0.062},
	    {"NY", 0.098},
	    {"OY", 0.036},
	    {"PY", 0.012},
	    {"RY", 0.248},
	    {"SY", 0.057},
	    {"TY", 0.227},
	    {"UY", 0.005},
	    {"VY", 0.005},
	    {"WY", 0.002},
	    {"XY", 0.003},
	    {"YY", 0.001},
	    {"ZY", 0.002},

	    {"AZ", 0.012},
	    {"CZ", 0.001},
	    {"EZ", 0.005},
	    {"IZ", 0.064},
	    {"MZ", 0.001},
	    {"NZ", 0.004},
	    {"OZ", 0.003},
	    {"RZ", 0.001},
	    {"TZ", 0.004},
	    {"UZ", 0.002},
	    {"YZ", 0.002},
	    {"ZZ", 0.003}
	};

	//Digrams to prevent from appearing at the start of the generation
	string[] disallowedForStart = new string[] {
		"bf","cb","cc","ce","ck","cw","df","dg","dl","dq","dt","ej","ff","gg","gh","hk","hl","ll","lk","lm","mp","mr","mz","nd","nk","nn","ns","nt","oo","rc","rd","rg","rk","rl","rm","rn","rp","rr","rs","rt","rv","rw","rx","sj","sr","ss","tc","tl","ts","tt","ug","vb","xc","xp","xs","xt","yc","yj","yr","yt","yy","zh","zk","zr","zs","zz"
	};

	//Groups of letters that are possible to appear, but that shouldn"t finish off a name
	string[] wordsToAvoidAtEnd = new string[] {
		"dri","li","sc","ixi","dr","ae","dla","bhe","bf","edl","kr","xo","vei","aiv","gr","sv","fha","sci","dl","dr","vb","nn","blu","eex","rrd","ji","gg","eew","whe","ecl","itl","dg","cb", "rw", "cr","fr"
	};

	Dictionary<string, List<DigramValue>> digramWordFreq = new Dictionary<string, List<DigramValue>>() {
		{
			"ab", 
			new List<DigramValue>() {
				new DigramValue("ba",.05),
				new DigramValue("be",.1),
				new DigramValue("bi",.1),
				new DigramValue("bl",.05),
				new DigramValue("bo",.05),
				new DigramValue("br",.1),
				new DigramValue("bu",.05),
				new DigramValue("by",.2)
			}
		},
		{
			"ac", 
			new List<DigramValue>() {
				new DigramValue("ca",.1),
				new DigramValue("cc",.05),
				new DigramValue("ce",.1),
				new DigramValue("ch",.1),
				new DigramValue("ci",.05),
				new DigramValue("cl",.1),
				new DigramValue("ck",.1),
				new DigramValue("co",.1),
				new DigramValue("cr",.1),
				new DigramValue("cu",.05),
				new DigramValue("cy",.05)
			}
		},
		{
			"ad", 
			new List<DigramValue>() {
				new DigramValue("da",.1),
				new DigramValue("de",.1),
				new DigramValue("df",.05),
				new DigramValue("dg",.05),
				new DigramValue("di",.1),
				new DigramValue("dj",.05),
				new DigramValue("dl",.1),
				new DigramValue("do",.1),
				new DigramValue("dr",.1),
				new DigramValue("dq",.05),
				new DigramValue("dt",.1),
				new DigramValue("dv",.05)
			}
		},
		{
			"ae", 
			new List<DigramValue>() {
				new DigramValue("eb",.025),
				new DigramValue("ec",.05),
				new DigramValue("ed",.05),
				new DigramValue("ek",.025),
				new DigramValue("el",.05),
				new DigramValue("ej",.025),
				new DigramValue("em",.05),
				new DigramValue("en",.05),
				new DigramValue("ep",.025),
				new DigramValue("eq",.025),
				new DigramValue("er",.05),
				new DigramValue("es",.05),
				new DigramValue("et",.05),
				new DigramValue("ev",.05),
				new DigramValue("ew",.05),
				new DigramValue("ex",.05),
				new DigramValue("ey",.025)
			}
		},
		{
			"af", 
			new List<DigramValue>() {
				new DigramValue("fa",.2),
				new DigramValue("fe",.1),
				new DigramValue("ff",.1),
				new DigramValue("fi",.1),
				new DigramValue("fl",.1),
				new DigramValue("fo",.1),
				new DigramValue("fr",.1),
				new DigramValue("fu",.1)
			}
		},
		{
			"ag", 
			new List<DigramValue>() {
				new DigramValue("ga",.1),
				new DigramValue("ge",.1),
				new DigramValue("gg",.1),
				new DigramValue("gh",.1),
				new DigramValue("gi",.1),
				new DigramValue("gl",.1),
				new DigramValue("gn",.05),
				new DigramValue("go",.1),
				new DigramValue("gr",.1),
				new DigramValue("gu",.1),
				new DigramValue("gy",.05)
			}
		},
		{
			"ah", 
			new List<DigramValue>() {
				new DigramValue("ha",.2),
				new DigramValue("he",.1),
				new DigramValue("hi",.1),
				new DigramValue("hk",.1),
				new DigramValue("hl",.1),
				new DigramValue("ho",.2),
				new DigramValue("hr",.1),
				new DigramValue("hu",.1)
			}
		},
		{
			"ai", 
			new List<DigramValue>() {
				new DigramValue("ic",.05),
				new DigramValue("id",.1),
				new DigramValue("if",.05),
				new DigramValue("ig",.05),
				new DigramValue("ik",.05),
				new DigramValue("il",.05),
				new DigramValue("im",.05),
				new DigramValue("in",.1),
				new DigramValue("ip",.05),
				new DigramValue("ir",.05), 
				new DigramValue("is",.1),
				new DigramValue("it",.1),
				new DigramValue("iv",.05),
				new DigramValue("ix",.05),
				new DigramValue("iz",.05)
			}
		},
		{
			"ak", 
			new List<DigramValue>() {
				new DigramValue("ka",.1),
				new DigramValue("ke",.1),
				new DigramValue("ki",.2),
				new DigramValue("kl",.1),
				new DigramValue("kn",.1),
				new DigramValue("ko",.1),
				new DigramValue("kr",.1),
				new DigramValue("ku",.1),
				new DigramValue("kv",.1)
			}
		},
		{
			"al", 
			new List<DigramValue>() {
				new DigramValue("la",.2),
				new DigramValue("le",.2),
				new DigramValue("li",.1),
				new DigramValue("ll",.1),
				new DigramValue("lk",.1),
				new DigramValue("lm",.1),
				new DigramValue("lo",.1),
				new DigramValue("lu",.1)
			}
		},
		{
			"am", 
			new List<DigramValue>() {
				new DigramValue("ma",.1),
				new DigramValue("me",.2),
				new DigramValue("mi",.1),
				new DigramValue("mo",.2),
				new DigramValue("mp",.1),
				new DigramValue("mr",.1),
				new DigramValue("mu",.1),
				new DigramValue("mz",.1)
			}
		},
		{
			"an", 
			new List<DigramValue>() {
				new DigramValue("na",.1),
				new DigramValue("nc",.05),
				new DigramValue("nd",.05),
				new DigramValue("ne",.1),
				new DigramValue("ni",.1),
				new DigramValue("nj",.05),
				new DigramValue("nk",.1),
				new DigramValue("nn",.1),
				new DigramValue("no",.1),
				new DigramValue("ns",.1),
				new DigramValue("nt",.1),
				new DigramValue("nu",.1)
			}
		},
		{
			"ap", 
			new List<DigramValue>() {
				new DigramValue("pa",.1),
				new DigramValue("pe",.1),
				new DigramValue("ph",.1),
				new DigramValue("pl",.1),
				new DigramValue("pn",.1),
				new DigramValue("po",.1),
				new DigramValue("pr",.1),
				new DigramValue("pu",.1),
				new DigramValue("py",.2)
			}
		},
		{
			"ar", 
			new List<DigramValue>() {
				new DigramValue("ra",.1),
				new DigramValue("rc",.05),
				new DigramValue("rd",.05),
				new DigramValue("re",.05),
				new DigramValue("rg",.05),
				new DigramValue("ri",.05),
				new DigramValue("rk",.05),
				new DigramValue("rl",.05),
				new DigramValue("rm",.05),
				new DigramValue("rn",.05),
				new DigramValue("ro",.05),
				new DigramValue("rp",.05),
				new DigramValue("rr",.05),
				new DigramValue("rs",.05),
				new DigramValue("rt",.05),
				new DigramValue("ru",.05),
				new DigramValue("rv",.05),
				new DigramValue("rw",.05),
				new DigramValue("rx",.05)
			}
		},
		{
			"as", 
			new List<DigramValue>() {
				new DigramValue("sa",.05),
				new DigramValue("sc",.1),
				new DigramValue("se",.05),
				new DigramValue("sh",.05),
				new DigramValue("si",.05),
				new DigramValue("sj",.05),
				new DigramValue("sk",.05),
				new DigramValue("sl",.05),
				new DigramValue("sm",.05),
				new DigramValue("sn",.05),
				new DigramValue("so",.05),
				new DigramValue("sp",.05),
				new DigramValue("sq",.05),
				new DigramValue("sr",.05),
				new DigramValue("ss",.05),
				new DigramValue("st",.05),
				new DigramValue("su",.05),
				new DigramValue("sv",.05),
				new DigramValue("sy",.05)
			}
		},
		{
			"at", 
			new List<DigramValue>() {
				new DigramValue("ta",.1),
				new DigramValue("tc",.05),
				new DigramValue("te",.1),
				new DigramValue("th",.1),
				new DigramValue("ti",.1),
				new DigramValue("tl",.05),
				new DigramValue("to",.1),
				new DigramValue("tr",.1),
				new DigramValue("ts",.05), 
				new DigramValue("tt",.1),
				new DigramValue("tu",.1),
				new DigramValue("ty",.05)
			}
		},
		{
			"au", 
			new List<DigramValue>() {
				new DigramValue("ub",.1),
				new DigramValue("uc",.05),
				new DigramValue("ud",.1),
				new DigramValue("ug",.05),
				new DigramValue("ul",.1),
				new DigramValue("um",.1),
				new DigramValue("un",.1),
				new DigramValue("up",.1),
				new DigramValue("ur",.1),
				new DigramValue("us",.1),
				new DigramValue("ut",.1)
			}
		},
		{
			"av", 
			new List<DigramValue>() {
				new DigramValue("va",.1),
				new DigramValue("vb",.1),
				new DigramValue("ve",.1),
				new DigramValue("vh",.1),
				new DigramValue("vi",.1),
				new DigramValue("vj",.05),
				new DigramValue("vl",.1),
				new DigramValue("vo",.1),
				new DigramValue("vr",.05),
				new DigramValue("vu",.1),
				new DigramValue("vy",.1)
			}
		},
		{
			"aw", 
			new List<DigramValue>() {
				new DigramValue("wa",.2),
				new DigramValue("we",.2),
				new DigramValue("wh",.1),
				new DigramValue("wi",.1),
				new DigramValue("wo",.1),
				new DigramValue("wr",.2),
				new DigramValue("wu",.1)
			}
		},
		{
			"ax", 
			new List<DigramValue>() {
				new DigramValue("xa",.2),
				new DigramValue("xc",.2),
				new DigramValue("xi",.1),
				new DigramValue("xo",.1),
				new DigramValue("xp",.1),
				new DigramValue("xs",.1),
				new DigramValue("xt",.1),
				new DigramValue("xu",.1)
			}
		},
		{
			"ay", 
			new List<DigramValue>() {
				new DigramValue("ya",.1),
				new DigramValue("yc",.1),
				new DigramValue("ye",.1),
				new DigramValue("yi",.1),
				new DigramValue("yj",.1),
				new DigramValue("yo",.1),
				new DigramValue("yr",.1),
				new DigramValue("yt",.1),
				new DigramValue("yu",.1),
				new DigramValue("yy",.1)
			}
		},
		{
			"az", 
			new List<DigramValue>() {
				new DigramValue("za",.1),
				new DigramValue("ze",.1),
				new DigramValue("zh",.1),
				new DigramValue("zi",.1),
				new DigramValue("zk",.1),
				new DigramValue("zo",.1),
				new DigramValue("zr",.1),
				new DigramValue("zs",.1),
				new DigramValue("zu",.1),
				new DigramValue("zz",.1)
			}
		},

		{
			"ba", 
			new List<DigramValue>() {
				new DigramValue("ab",.025),
				new DigramValue("ac",.075),
				new DigramValue("ad",.075),
				new DigramValue("ae",.025),
				new DigramValue("af",.025),
				new DigramValue("ag",.075),
				new DigramValue("ah",.075),
				new DigramValue("ai",.025),
				new DigramValue("ak",.05),
				new DigramValue("al",.05),
				new DigramValue("am",.05),
				new DigramValue("an",.05),
				new DigramValue("ap",.025),
				new DigramValue("ar",.075),
				new DigramValue("as",.05),
				new DigramValue("at",.05),
				new DigramValue("au",.05),
				new DigramValue("av",.05),
				new DigramValue("aw",.025),
				new DigramValue("ax",.025),
				new DigramValue("ay",.025),
				new DigramValue("az",.025)
			}
		},
		{
			"be", 
			new List<DigramValue>() {
				new DigramValue("ea",.05),
				new DigramValue("eb",.025),
				new DigramValue("ec",.05),
				new DigramValue("ed",.05),
				new DigramValue("ef",.025),
				new DigramValue("eg",.05),
				new DigramValue("eh",.025),
				new DigramValue("ei",.05),
				new DigramValue("ek",.025),
				new DigramValue("ee",.05),
				new DigramValue("el",.05),
				new DigramValue("ej",.025),
				new DigramValue("em",.05),
				new DigramValue("en",.05),
				new DigramValue("ep",.025),
				new DigramValue("eq",.025),
				new DigramValue("er",.05),
				new DigramValue("es",.05),
				new DigramValue("et",.05),
				new DigramValue("ev",.05),
				new DigramValue("ew",.05),
				new DigramValue("ex",.05),
				new DigramValue("ey",.025)
			}
		},
		{
			"bf", 
			new List<DigramValue>() {
				new DigramValue("fa",.2),
				new DigramValue("fe",.1),
				new DigramValue("ff",.1),
				new DigramValue("fh",.1),
				new DigramValue("fi",.1),
				new DigramValue("fl",.1),
				new DigramValue("fo",.1),
				new DigramValue("fr",.1),
				new DigramValue("fu",.1)
			}
		},
		{
			"bh", 
			new List<DigramValue>() {
				new DigramValue("ha",.2),
				new DigramValue("he",.1),
				new DigramValue("hi",.1),
				new DigramValue("ho",.2),
				new DigramValue("hu",.1)
			}
		},
		{
			"bi", 
			new List<DigramValue>() {
				new DigramValue("ic",.05),
				new DigramValue("id",.1),
				new DigramValue("if",.05),
				new DigramValue("ig",.05),
				new DigramValue("ik",.05),
				new DigramValue("il",.05),
				new DigramValue("im",.05),
				new DigramValue("in",.1),
				new DigramValue("io",.05),
				new DigramValue("ip",.05),
				new DigramValue("ir",.05), 
				new DigramValue("is",.1),
				new DigramValue("it",.1),
				new DigramValue("iv",.05),
				new DigramValue("ix",.05),
				new DigramValue("iz",.05)
			}
		},
		{
			"bl", 
			new List<DigramValue>() {
				new DigramValue("la",.2),
				new DigramValue("le",.2),
				new DigramValue("li",.1),
				new DigramValue("lo",.1),
				new DigramValue("lu",.1)
			}
		},
		{
			"bo", 
			new List<DigramValue>() {
				new DigramValue("ob",.05),
				new DigramValue("oc",.05),
				new DigramValue("od",.1),
				new DigramValue("of",.05),
				new DigramValue("og",.05),
				new DigramValue("ok",.05),
				new DigramValue("ol",.05),
				new DigramValue("on",.1),
				new DigramValue("oo",.05),
				new DigramValue("op",.05),
				new DigramValue("or",.1),
				new DigramValue("os",.1),
				new DigramValue("ot",.05),
				new DigramValue("ov",.05),
				new DigramValue("ow",.05),
				new DigramValue("oy",.05)
			}
		},
		{
			"br", 
			new List<DigramValue>() {
				new DigramValue("ra",.1),
				new DigramValue("re",.05),
				new DigramValue("ri",.05),
				new DigramValue("ro",.05),
				new DigramValue("ru",.05)
			}
		},
		{
			"bu", 
			new List<DigramValue>() {
				new DigramValue("ub",.1),
				new DigramValue("uc",.05),
				new DigramValue("ud",.1),
				new DigramValue("ug",.05),
				new DigramValue("ul",.1),
				new DigramValue("um",.1),
				new DigramValue("un",.1),
				new DigramValue("up",.1),
				new DigramValue("ur",.1),
				new DigramValue("us",.1),
				new DigramValue("ut",.1)
			}
		},
		{
			"by", 
			new List<DigramValue>() {
				new DigramValue("ya",.1),
				new DigramValue("yc",.1),
				new DigramValue("ye",.1),
				new DigramValue("yi",.1),
				new DigramValue("yj",.1),
				new DigramValue("yo",.1),
				new DigramValue("yr",.1),
				new DigramValue("yt",.1),
				new DigramValue("yu",.1),
				new DigramValue("yy",.1)
			}
		},

		{
			"ca", 
			new List<DigramValue>() {
				new DigramValue("ab",.05),
				new DigramValue("ac",.05),
				new DigramValue("ad",.05),
				new DigramValue("ae",.05),
				new DigramValue("af",.05),
				new DigramValue("ag",.05),
				new DigramValue("ah",.05),
				new DigramValue("ai",.05),
				new DigramValue("ak",.05),
				new DigramValue("al",.05),
				new DigramValue("am",.05),
				new DigramValue("an",.05),
				new DigramValue("ap",.05),
				new DigramValue("ar",.05),
				new DigramValue("as",.05),
				new DigramValue("at",.05),
				new DigramValue("au",.05),
				new DigramValue("av",.05),
				new DigramValue("aw",.025),
				new DigramValue("ax",.025),
				new DigramValue("ay",.025),
				new DigramValue("az",.025)
			}
		},
		{
			"cb", 
			new List<DigramValue>() {
				new DigramValue("ba",.1),
				new DigramValue("be",.1),
				new DigramValue("bi",.1),
				new DigramValue("bo",.1),
				new DigramValue("by",.1)
			}
		},
		{
			"cc", 
			new List<DigramValue>() {
				new DigramValue("ca",.1),
				new DigramValue("ce",.1),
				new DigramValue("ci",.05),
				new DigramValue("co",.1),
				new DigramValue("cu",.05),
				new DigramValue("cy",.05)
			}
		},
		{
			"ce", 
			new List<DigramValue>() {
				new DigramValue("ea",.05),
				new DigramValue("eb",.025),
				new DigramValue("ed",.05),
				new DigramValue("ef",.025),
				new DigramValue("eg",.05),
				new DigramValue("eh",.025),
				new DigramValue("ek",.025),
				new DigramValue("el",.05),
				new DigramValue("em",.05),
				new DigramValue("en",.05),
				new DigramValue("ep",.025),
				new DigramValue("er",.05),
				new DigramValue("es",.05),
				new DigramValue("et",.05),
				new DigramValue("ev",.05),
				new DigramValue("ew",.05),
				new DigramValue("ex",.05),
				new DigramValue("ey",.025)
			}
		},
		{
			"ch", 
			new List<DigramValue>() {
				new DigramValue("ha",.2),
				new DigramValue("he",.1),
				new DigramValue("hi",.1),
				new DigramValue("ho",.2),
				new DigramValue("hr",.1),
				new DigramValue("hu",.1)
			}
		},
		{
			"ci", 
			new List<DigramValue>() {
				new DigramValue("ic",.05),
				new DigramValue("id",.1),
				new DigramValue("if",.05),
				new DigramValue("ig",.05),
				new DigramValue("ik",.05),
				new DigramValue("il",.05),
				new DigramValue("im",.05),
				new DigramValue("in",.1),
				new DigramValue("io",.05),
				new DigramValue("ip",.05),
				new DigramValue("ir",.05), 
				new DigramValue("is",.1),
				new DigramValue("it",.1),
				new DigramValue("iv",.05),
				new DigramValue("ix",.05),
				new DigramValue("iz",.05)
			}
		},
		{
			"cl", 
			new List<DigramValue>() {
				new DigramValue("la",.2),
				new DigramValue("le",.2),
				new DigramValue("li",.1),
				new DigramValue("lo",.1),
				new DigramValue("lu",.1)
			}
		},
		{
			"ck", 
			new List<DigramValue>() {
				new DigramValue("ka",.1),
				new DigramValue("ke",.1),
				new DigramValue("ko",.1)
			}
		},
		{
			"co", 
			new List<DigramValue>() {
				new DigramValue("ob",.05),
				new DigramValue("oc",.05),
				new DigramValue("od",.1),
				new DigramValue("of",.05),
				new DigramValue("og",.05),
				new DigramValue("ok",.05),
				new DigramValue("ol",.05),
				new DigramValue("on",.1),
				new DigramValue("oo",.05),
				new DigramValue("op",.05),
				new DigramValue("or",.1),
				new DigramValue("os",.1),
				new DigramValue("ot",.05),
				new DigramValue("ov",.05),
				new DigramValue("ow",.05),
				new DigramValue("oy",.05)
			}
		},
		{
			"cr", 
			new List<DigramValue>() {
				new DigramValue("ra",.1),
				new DigramValue("re",.05),
				new DigramValue("ri",.05),
				new DigramValue("ro",.05),
				new DigramValue("ru",.05)
			}
		},
		{
			"cu", 
			new List<DigramValue>() {
				new DigramValue("ub",.1),
				new DigramValue("uc",.05),
				new DigramValue("ud",.1),
				new DigramValue("ug",.05),
				new DigramValue("ul",.1),
				new DigramValue("um",.1),
				new DigramValue("un",.1),
				new DigramValue("up",.1),
				new DigramValue("ur",.1),
				new DigramValue("us",.1),
				new DigramValue("ut",.1)
			}
		},
		{
			"cw", 
			new List<DigramValue>() {
				new DigramValue("wa",.2),
				new DigramValue("we",.2),
				new DigramValue("wo",.1)
			}
		},
		{
			"cy", 
			new List<DigramValue>() {
				new DigramValue("ya",.1),
				new DigramValue("yc",.1),
				new DigramValue("ye",.1),
				new DigramValue("yo",.1),
				new DigramValue("yr",.1)
			}
		},

		{
			"da", 
			new List<DigramValue>() {
				new DigramValue("ab",.05),
				new DigramValue("ac",.05),
				new DigramValue("ae",.05),
				new DigramValue("ag",.05),
				new DigramValue("ah",.05),
				new DigramValue("ak",.05),
				new DigramValue("al",.05),
				new DigramValue("am",.05),
				new DigramValue("an",.05),
				new DigramValue("ap",.05),
				new DigramValue("ar",.05),
				new DigramValue("as",.05),
				new DigramValue("at",.05),
				new DigramValue("au",.05),
				new DigramValue("av",.05),
				new DigramValue("ax",.025),
				new DigramValue("ay",.025)
			}
		},
		{
			"de", 
			new List<DigramValue>() {
				new DigramValue("ea",.05),
				new DigramValue("eb",.025),
				new DigramValue("ec",.05),
				new DigramValue("ed",.05),
				new DigramValue("ef",.025),
				new DigramValue("eg",.05),
				new DigramValue("eh",.025),
				new DigramValue("ei",.05),
				new DigramValue("ek",.025),
				new DigramValue("ee",.05),
				new DigramValue("el",.05),
				new DigramValue("ej",.025),
				new DigramValue("em",.05),
				new DigramValue("en",.05),
				new DigramValue("ep",.025),
				new DigramValue("eq",.025),
				new DigramValue("er",.05),
				new DigramValue("es",.05),
				new DigramValue("et",.05),
				new DigramValue("ev",.05),
				new DigramValue("ew",.05),
				new DigramValue("ex",.05),
				new DigramValue("ey",.025)
			}
		},
		{
			"df", 
			new List<DigramValue>() {
				new DigramValue("fa",.2),
				new DigramValue("fe",.1),
				new DigramValue("fi",.1),
				new DigramValue("fl",.1),
				new DigramValue("fo",.1),
				new DigramValue("fr",.1),
				new DigramValue("fu",.1)
			}
		},
		{
			"dg", 
			new List<DigramValue>() {
				new DigramValue("ga",.1),
				new DigramValue("ge",.1),
				new DigramValue("gi",.1),
				new DigramValue("go",.1)
			}
		},
		{
			"di", 
			new List<DigramValue>() {
				new DigramValue("ic",.05),
				new DigramValue("id",.1),
				new DigramValue("if",.05),
				new DigramValue("ig",.05),
				new DigramValue("ik",.05),
				new DigramValue("il",.05),
				new DigramValue("im",.05),
				new DigramValue("in",.1),
				new DigramValue("io",.05),
				new DigramValue("ip",.05),
				new DigramValue("ir",.05), 
				new DigramValue("is",.1),
				new DigramValue("it",.1),
				new DigramValue("iv",.05),
				new DigramValue("ix",.05),
				new DigramValue("iz",.05)
			}
		},
		{
			"dj", 
			new List<DigramValue>() {
				new DigramValue("ja",.2),
				new DigramValue("je",.2),
				new DigramValue("ji",.2),
				new DigramValue("jo",.2),
				new DigramValue("ju",.2)
			}
		},
		{
			"dl", 
			new List<DigramValue>() {
				new DigramValue("la",.2),
				new DigramValue("le",.2),
				new DigramValue("li",.1),
				new DigramValue("lo",.1),
				new DigramValue("lu",.1)
			}
		},
		{
			"do", 
			new List<DigramValue>() {
				new DigramValue("ob",.05),
				new DigramValue("oc",.05),
				new DigramValue("od",.1),
				new DigramValue("of",.05),
				new DigramValue("og",.05),
				new DigramValue("ok",.05),
				new DigramValue("ol",.05),
				new DigramValue("on",.1),
				new DigramValue("oo",.05),
				new DigramValue("op",.05),
				new DigramValue("or",.1),
				new DigramValue("os",.1),
				new DigramValue("ot",.05),
				new DigramValue("ov",.05),
				new DigramValue("ow",.05),
				new DigramValue("oy",.05)
			}
		},
		{
			"dr", 
			new List<DigramValue>() {
				new DigramValue("ra",.1),
				new DigramValue("re",.05),
				new DigramValue("ri",.05),
				new DigramValue("ro",.05),
				new DigramValue("ru",.05)
			}
		},
		{
			"dq", 
			new List<DigramValue>() {
				new DigramValue("qa",.5), 
				new DigramValue("qu",.5)
			}
		},
		{
			"dt", 
			new List<DigramValue>() {
				new DigramValue("ta",.1),
				new DigramValue("te",.1),
				new DigramValue("to",.1),
				new DigramValue("ty",.05)
			}
		},
		{
			"dv", 
			new List<DigramValue>() {
				new DigramValue("va",.1),
				new DigramValue("ve",.1),
				new DigramValue("vo",.1)
			}
		},

		{
			"ea", 
			new List<DigramValue>() {
				new DigramValue("ab",.05),
				new DigramValue("ac",.05),
				new DigramValue("ad",.05),
				new DigramValue("ae",.05),
				new DigramValue("af",.05),
				new DigramValue("ag",.05),
				new DigramValue("ah",.05),
				new DigramValue("ai",.05),
				new DigramValue("ak",.05),
				new DigramValue("al",.05),
				new DigramValue("am",.05),
				new DigramValue("an",.05),
				new DigramValue("ap",.05),
				new DigramValue("ar",.05),
				new DigramValue("as",.05),
				new DigramValue("at",.05),
				new DigramValue("au",.05),
				new DigramValue("av",.05),
				new DigramValue("aw",.025),
				new DigramValue("ax",.025),
				new DigramValue("ay",.025),
				new DigramValue("az",.025)
			}
		},
		{
			"eb", 
			new List<DigramValue>() {
				new DigramValue("ba",.1),
				new DigramValue("be",.1),
				new DigramValue("bf",.1),
				new DigramValue("bh",.1),
				new DigramValue("bi",.1),
				new DigramValue("bl",.1),
				new DigramValue("bo",.1),
				new DigramValue("br",.1),
				new DigramValue("bu",.1),
				new DigramValue("by",.1)
			}
		},
		{
			"ec", 
			new List<DigramValue>() {
				new DigramValue("ca",.1),
				new DigramValue("cb",.05),
				new DigramValue("cc",.05),
				new DigramValue("ce",.1),
				new DigramValue("ch",.1),
				new DigramValue("ci",.05),
				new DigramValue("cl",.1),
				new DigramValue("ck",.1),
				new DigramValue("co",.1),
				new DigramValue("cr",.1),
				new DigramValue("cu",.05),
				new DigramValue("cw",.05),
				new DigramValue("cy",.05)
			}
		},
		{
			"ed", 
			new List<DigramValue>() {
				new DigramValue("da",.1),
				new DigramValue("de",.1),
				new DigramValue("df",.05),
				new DigramValue("dg",.05),
				new DigramValue("di",.1),
				new DigramValue("dj",.05),
				new DigramValue("dl",.1),
				new DigramValue("do",.1),
				new DigramValue("dr",.1),
				new DigramValue("dq",.05),
				new DigramValue("dt",.1),
				new DigramValue("dv",.05)
			}
		},
		{
			"ef", 
			new List<DigramValue>() {
				new DigramValue("fa",.2),
				new DigramValue("fe",.1),
				new DigramValue("ff",.1),
				new DigramValue("fh",.1),
				new DigramValue("fi",.1),
				new DigramValue("fl",.1),
				new DigramValue("fo",.1),
				new DigramValue("fr",.1),
				new DigramValue("fu",.1)
			}
		},
		{
			"eg", 
			new List<DigramValue>() {
				new DigramValue("ga",.1),
				new DigramValue("ge",.1),
				new DigramValue("gg",.1),
				new DigramValue("gh",.1),
				new DigramValue("gi",.1),
				new DigramValue("gl",.1),
				new DigramValue("gn",.05),
				new DigramValue("go",.1),
				new DigramValue("gr",.1),
				new DigramValue("gu",.1),
				new DigramValue("gy",.05)
			}
		},
		{
			"eh", 
			new List<DigramValue>() {
				new DigramValue("ha",.2),
				new DigramValue("he",.1),
				new DigramValue("hi",.1),
				new DigramValue("hk",.1),
				new DigramValue("hl",.1),
				new DigramValue("ho",.2),
				new DigramValue("hr",.1),
				new DigramValue("hu",.1)
			}
		},
		{
			"ei", 
			new List<DigramValue>() {
				new DigramValue("id",.1),
				new DigramValue("ik",.05),
				new DigramValue("il",.05),
				new DigramValue("im",.05),
				new DigramValue("in",.1),
				new DigramValue("is",.1)
			}
		},
		{
			"ek", 
			new List<DigramValue>() {
				new DigramValue("ka",.1),
				new DigramValue("ke",.1),
				new DigramValue("ki",.2),
				new DigramValue("kl",.1),
				new DigramValue("kn",.1),
				new DigramValue("ko",.1),
				new DigramValue("kr",.1),
				new DigramValue("ku",.1),
				new DigramValue("kv",.1)
			}
		},
		{
			"ee", 
			new List<DigramValue>() {
				new DigramValue("eb",.025),
				new DigramValue("ed",.05),
				new DigramValue("ef",.025),
				new DigramValue("eg",.05),
				new DigramValue("eh",.025),
				new DigramValue("ek",.025),
				new DigramValue("el",.05),
				new DigramValue("ej",.025),
				new DigramValue("em",.05),
				new DigramValue("en",.05),
				new DigramValue("ep",.025),
				new DigramValue("eq",.025),
				new DigramValue("er",.05),
				new DigramValue("es",.05),
				new DigramValue("et",.05),
				new DigramValue("ev",.05),
				new DigramValue("ew",.05),
				new DigramValue("ex",.05),
				new DigramValue("ey",.025)
			}
		},
		{
			"el", 
			new List<DigramValue>() {
				new DigramValue("la",.2),
				new DigramValue("le",.2),
				new DigramValue("li",.1),
				new DigramValue("ll",.1),
				new DigramValue("lk",.1),
				new DigramValue("lm",.1),
				new DigramValue("lo",.1),
				new DigramValue("lu",.1)
			}
		},
		{
			"ej", 
			new List<DigramValue>() {
				new DigramValue("ja",.2),
				new DigramValue("je",.2),
				new DigramValue("ji",.2),
				new DigramValue("jo",.2),
				new DigramValue("ju",.2)
			}
		},
		{
			"em", 
			new List<DigramValue>() {
				new DigramValue("ma",.1),
				new DigramValue("me",.2),
				new DigramValue("mi",.1),
				new DigramValue("mo",.2),
				new DigramValue("mp",.1),
				new DigramValue("mr",.1),
				new DigramValue("mu",.1),
				new DigramValue("mz",.1)
			}
		},
		{
			"en", 
			new List<DigramValue>() {
				new DigramValue("na",.1),
				new DigramValue("nc",.05),
				new DigramValue("nd",.05),
				new DigramValue("ne",.1),
				new DigramValue("ni",.1),
				new DigramValue("nj",.05),
				new DigramValue("nk",.1),
				new DigramValue("nn",.1),
				new DigramValue("no",.1),
				new DigramValue("ns",.1),
				new DigramValue("nt",.1),
				new DigramValue("nu",.1)
			}
		},
		{
			"ep", 
			new List<DigramValue>() {
				new DigramValue("pa",.1),
				new DigramValue("pe",.1),
				new DigramValue("ph",.1),
				new DigramValue("pl",.1),
				new DigramValue("po",.1),
				new DigramValue("pr",.1),
				new DigramValue("pu",.1),
				new DigramValue("py",.2)
			}
		},
		{
			"eq", 
			new List<DigramValue>() {
				new DigramValue("qa",.5), 
				new DigramValue("qu",.5)
			}
		},
		{
			"er", 
			new List<DigramValue>() {
				new DigramValue("ra",.1),
				new DigramValue("rc",.05),
				new DigramValue("rd",.05),
				new DigramValue("re",.05),
				new DigramValue("rg",.05),
				new DigramValue("ri",.05),
				new DigramValue("rk",.05),
				new DigramValue("rl",.05),
				new DigramValue("rm",.05),
				new DigramValue("rn",.05),
				new DigramValue("ro",.05),
				new DigramValue("rp",.05),
				new DigramValue("rr",.05),
				new DigramValue("rs",.05),
				new DigramValue("rt",.05),
				new DigramValue("ru",.05),
				new DigramValue("rv",.05),
				new DigramValue("rw",.05),
				new DigramValue("rx",.05)
			}
		},
		{
			"es", 
			new List<DigramValue>() {
				new DigramValue("sa",.05),
				new DigramValue("sc",.1),
				new DigramValue("se",.05),
				new DigramValue("sh",.05),
				new DigramValue("si",.05),
				new DigramValue("sj",.05),
				new DigramValue("sk",.05),
				new DigramValue("sl",.05),
				new DigramValue("sm",.05),
				new DigramValue("sn",.05),
				new DigramValue("so",.05),
				new DigramValue("sp",.05),
				new DigramValue("sq",.05),
				new DigramValue("sr",.05),
				new DigramValue("ss",.05),
				new DigramValue("st",.05),
				new DigramValue("su",.05),
				new DigramValue("sv",.05),
				new DigramValue("sy",.05)
			}
		},
		{
			"et", 
			new List<DigramValue>() {
				new DigramValue("ta",.1),
				new DigramValue("tc",.05),
				new DigramValue("te",.1),
				new DigramValue("th",.1),
				new DigramValue("ti",.1),
				new DigramValue("tl",.05),
				new DigramValue("to",.1),
				new DigramValue("tr",.1),
				new DigramValue("ts",.05),
 				new DigramValue("tt",.1),
				new DigramValue("tu",.1),
				new DigramValue("ty",.05)
			}
		},
		{
			"ev", 
			new List<DigramValue>() {
				new DigramValue("va",.1),
				new DigramValue("vb",.1),
				new DigramValue("ve",.1),
				new DigramValue("vh",.1),
				new DigramValue("vi",.1),
				new DigramValue("vj",.05),
				new DigramValue("vl",.1),
				new DigramValue("vo",.1),
				new DigramValue("vr",.05),
				new DigramValue("vu",.1),
				new DigramValue("vy",.1)
			}
		},
		{
			"ew", 
			new List<DigramValue>() {
				new DigramValue("wa",.2),
				new DigramValue("we",.2),
				new DigramValue("wh",.1),
				new DigramValue("wi",.1),
				new DigramValue("wo",.1),
				new DigramValue("wr",.2),
				new DigramValue("wu",.1)
			}
		},
		{
			"ex", 
			new List<DigramValue>() {
				new DigramValue("xa",.2),
				new DigramValue("xc",.2),
				new DigramValue("xi",.1),
				new DigramValue("xo",.1),
				new DigramValue("xp",.1),
				new DigramValue("xs",.1),
				new DigramValue("xt",.1),
				new DigramValue("xu",.1)
			}
		},
		{
			"ey", 
			new List<DigramValue>() {
				new DigramValue("ya",.1),
				new DigramValue("yc",.1),
				new DigramValue("ye",.1),
				new DigramValue("yi",.1),
				new DigramValue("yj",.1),
				new DigramValue("yo",.1),
				new DigramValue("yr",.1),
				new DigramValue("yt",.1),
				new DigramValue("yu",.1),
				new DigramValue("yy",.1)
			}
		},

		{
			"fa", 
			new List<DigramValue>() {
				new DigramValue("ab",.05),
				new DigramValue("ac",.05),
				new DigramValue("ad",.05),
				new DigramValue("ae",.05),
				new DigramValue("af",.05),
				new DigramValue("ag",.05),
				new DigramValue("ah",.05),
				new DigramValue("ai",.05),
				new DigramValue("ak",.05),
				new DigramValue("al",.05),
				new DigramValue("am",.05),
				new DigramValue("an",.05),
				new DigramValue("ap",.05),
				new DigramValue("ar",.05),
				new DigramValue("as",.05),
				new DigramValue("at",.05),
				new DigramValue("au",.05),
				new DigramValue("av",.05),
				new DigramValue("aw",.025),
				new DigramValue("ax",.025),
				new DigramValue("ay",.025),
				new DigramValue("az",.025)
			}
		},
		{
			"fe", 
			new List<DigramValue>() {
				new DigramValue("ea",.05),
				new DigramValue("eb",.025),
				new DigramValue("ec",.05),
				new DigramValue("ed",.05),
				new DigramValue("ef",.025),
				new DigramValue("eg",.05),
				new DigramValue("eh",.025),
				new DigramValue("ei",.05),
				new DigramValue("ek",.025),
				new DigramValue("ee",.05),
				new DigramValue("el",.05),
				new DigramValue("ej",.025),
				new DigramValue("em",.05),
				new DigramValue("en",.05),
				new DigramValue("ep",.025),
				new DigramValue("eq",.025),
				new DigramValue("er",.05),
				new DigramValue("es",.05),
				new DigramValue("et",.05),
				new DigramValue("ev",.05),
				new DigramValue("ew",.05),
				new DigramValue("ex",.05),
				new DigramValue("ey",.025)
			}
		},
		{
			"ff", 
			new List<DigramValue>() {
				new DigramValue("fa",.2),
				new DigramValue("fe",.1),
				new DigramValue("fi",.1),
				new DigramValue("fo",.1),
				new DigramValue("fu",.1)
			}
		},
		{
			"fh", 
			new List<DigramValue>() {
				new DigramValue("ha",.2),
				new DigramValue("he",.1),
				new DigramValue("hi",.1),
				new DigramValue("ho",.2),
				new DigramValue("hu",.1)
			}
		},
		{
			"fi", 
			new List<DigramValue>() {
				new DigramValue("ic",.05),
				new DigramValue("id",.1),
				new DigramValue("if",.05),
				new DigramValue("ig",.05),
				new DigramValue("ik",.05),
				new DigramValue("il",.05),
				new DigramValue("im",.05),
				new DigramValue("in",.1),
				new DigramValue("io",.05),
				new DigramValue("ip",.05),
				new DigramValue("ir",.05), 
				new DigramValue("is",.1),
				new DigramValue("it",.1),
				new DigramValue("iv",.05),
				new DigramValue("ix",.05),
				new DigramValue("iz",.05)
			}
		},
		{
			"fl", 
			new List<DigramValue>() {
				new DigramValue("la",.2),
				new DigramValue("le",.2),
				new DigramValue("li",.1),
				new DigramValue("lo",.1),
				new DigramValue("lu",.1)
			}
		},
		{
			"fo", 
			new List<DigramValue>() {
				new DigramValue("ob",.05),
				new DigramValue("oc",.05),
				new DigramValue("od",.1),
				new DigramValue("of",.05),
				new DigramValue("og",.05),
				new DigramValue("ok",.05),
				new DigramValue("ol",.05),
				new DigramValue("on",.1),
				new DigramValue("oo",.05),
				new DigramValue("op",.05),
				new DigramValue("or",.1),
				new DigramValue("os",.1),
				new DigramValue("ot",.05),
				new DigramValue("ov",.05),
				new DigramValue("ow",.05),
				new DigramValue("oy",.05)
			}
		},
		{
			"fr", 
			new List<DigramValue>() {
				new DigramValue("ra",.1),
				new DigramValue("re",.05),
				new DigramValue("ri",.05),
				new DigramValue("ro",.05),
				new DigramValue("ru",.05)
			}
		},
		{
			"fu", 
			new List<DigramValue>() {
				new DigramValue("ub",.1),
				new DigramValue("uc",.05),
				new DigramValue("ud",.1),
				new DigramValue("ug",.05),
				new DigramValue("ul",.1),
				new DigramValue("um",.1),
				new DigramValue("un",.1),
				new DigramValue("up",.1),
				new DigramValue("ur",.1),
				new DigramValue("us",.1),
				new DigramValue("ut",.1)
			}
		},

		{
			"ga", 
			new List<DigramValue>() {
				new DigramValue("ab",.05),
				new DigramValue("ac",.05),
				new DigramValue("ad",.05),
				new DigramValue("ae",.05),
				new DigramValue("af",.05),
				new DigramValue("ag",.05),
				new DigramValue("ah",.05),
				new DigramValue("ai",.05),
				new DigramValue("ak",.05),
				new DigramValue("al",.05),
				new DigramValue("am",.05),
				new DigramValue("an",.05),
				new DigramValue("ap",.05),
				new DigramValue("ar",.05),
				new DigramValue("as",.05),
				new DigramValue("at",.05),
				new DigramValue("au",.05),
				new DigramValue("av",.05),
				new DigramValue("aw",.025),
				new DigramValue("ax",.025),
				new DigramValue("ay",.025),
				new DigramValue("az",.025)
			}
		},
		{
			"ge", 
			new List<DigramValue>() {
				new DigramValue("ea",.05),
				new DigramValue("eb",.025),
				new DigramValue("ec",.05),
				new DigramValue("ed",.05),
				new DigramValue("ef",.025),
				new DigramValue("eg",.05),
				new DigramValue("eh",.025),
				new DigramValue("ei",.05),
				new DigramValue("ek",.025),
				new DigramValue("ee",.05),
				new DigramValue("el",.05),
				new DigramValue("ej",.025),
				new DigramValue("em",.05),
				new DigramValue("en",.05),
				new DigramValue("ep",.025),
				new DigramValue("eq",.025),
				new DigramValue("er",.05),
				new DigramValue("es",.05),
				new DigramValue("et",.05),
				new DigramValue("ev",.05),
				new DigramValue("ew",.05),
				new DigramValue("ex",.05),
				new DigramValue("ey",.025)
			}
		},
		{
			"gg", 
			new List<DigramValue>() {
				new DigramValue("ga",.1),
				new DigramValue("ge",.1),
				new DigramValue("gi",.1),
				new DigramValue("go",.1),
				new DigramValue("gr",.1),
				new DigramValue("gu",.1),
				new DigramValue("gy",.05)
			}
		},
		{
			"gh", 
			new List<DigramValue>() {
				new DigramValue("ha",.2),
				new DigramValue("he",.1),
				new DigramValue("hi",.1),
				new DigramValue("ho",.2),
				new DigramValue("hu",.1)
			}
		},
		{
			"gi", 
			new List<DigramValue>() {
				new DigramValue("ic",.05),
				new DigramValue("id",.1),
				new DigramValue("if",.05),
				new DigramValue("ig",.05),
				new DigramValue("ik",.05),
				new DigramValue("il",.05),
				new DigramValue("im",.05),
				new DigramValue("in",.1),
				new DigramValue("io",.05),
				new DigramValue("ip",.05),
				new DigramValue("ir",.05), 
				new DigramValue("is",.1),
				new DigramValue("it",.1),
				new DigramValue("iv",.05),
				new DigramValue("ix",.05),
				new DigramValue("iz",.05)
			}
		},
		{
			"gl", 
			new List<DigramValue>() {
				new DigramValue("la",.2),
				new DigramValue("le",.2),
				new DigramValue("li",.1),
				new DigramValue("lo",.1),
				new DigramValue("lu",.1)
			}
		},
		{
			"gn", 
			new List<DigramValue>() {
				new DigramValue("na",.1),
				new DigramValue("ne",.1),
				new DigramValue("ni",.1),
				new DigramValue("no",.1),
				new DigramValue("nu",.1)
			}
		},
		{
			"go", 
			new List<DigramValue>() {
				new DigramValue("ob",.05),
				new DigramValue("oc",.05),
				new DigramValue("od",.1),
				new DigramValue("of",.05),
				new DigramValue("og",.05),
				new DigramValue("ok",.05),
				new DigramValue("ol",.05),
				new DigramValue("on",.1),
				new DigramValue("oo",.05),
				new DigramValue("op",.05),
				new DigramValue("or",.1),
				new DigramValue("os",.1),
				new DigramValue("ot",.05),
				new DigramValue("ov",.05),
				new DigramValue("ow",.05),
				new DigramValue("oy",.05)
			}
		},
		{
			"gr", 
			new List<DigramValue>() {
				new DigramValue("ra",.1),
				new DigramValue("re",.05),
				new DigramValue("ri",.05),
				new DigramValue("ro",.05),
				new DigramValue("ru",.05)
			}
		},
		{
			"gu", 
			new List<DigramValue>() {
				new DigramValue("ub",.1),
				new DigramValue("uc",.05),
				new DigramValue("ud",.1),
				new DigramValue("ug",.05),
				new DigramValue("ul",.1),
				new DigramValue("um",.1),
				new DigramValue("un",.1),
				new DigramValue("up",.1),
				new DigramValue("ur",.1),
				new DigramValue("us",.1),
				new DigramValue("ut",.1)
			}
		},
		{
			"gy", 
			new List<DigramValue>() {
				new DigramValue("ya",.1),
				new DigramValue("ye",.1),
				new DigramValue("yi",.1),
				new DigramValue("yo",.1),
				new DigramValue("yr",.1),
				new DigramValue("yu",.1)
			}
		},

		{
			"ha", 
			new List<DigramValue>() {
				new DigramValue("ab",.05),
				new DigramValue("ac",.05),
				new DigramValue("ad",.05),
				new DigramValue("ae",.05),
				new DigramValue("af",.05),
				new DigramValue("ag",.05),
				new DigramValue("ah",.05),
				new DigramValue("ai",.05),
				new DigramValue("ak",.05),
				new DigramValue("al",.05),
				new DigramValue("am",.05),
				new DigramValue("an",.05),
				new DigramValue("ap",.05),
				new DigramValue("ar",.05),
				new DigramValue("as",.05),
				new DigramValue("at",.05),
				new DigramValue("au",.05),
				new DigramValue("av",.05),
				new DigramValue("aw",.025),
				new DigramValue("ax",.025),
				new DigramValue("ay",.025),
				new DigramValue("az",.025)
			}
		},
		{
			"he", 
			new List<DigramValue>() {
				new DigramValue("ea",.05),
				new DigramValue("eb",.025),
				new DigramValue("ec",.05),
				new DigramValue("ed",.05),
				new DigramValue("ef",.025),
				new DigramValue("eg",.05),
				new DigramValue("eh",.025),
				new DigramValue("ei",.05),
				new DigramValue("ek",.025),
				new DigramValue("ee",.05),
				new DigramValue("el",.05),
				new DigramValue("ej",.025),
				new DigramValue("em",.05),
				new DigramValue("en",.05),
				new DigramValue("ep",.025),
				new DigramValue("eq",.025),
				new DigramValue("er",.05),
				new DigramValue("es",.05),
				new DigramValue("et",.05),
				new DigramValue("ev",.05),
				new DigramValue("ew",.05),
				new DigramValue("ex",.05),
				new DigramValue("ey",.025)
			}
		},
		{
			"hi", 
			new List<DigramValue>() {
				new DigramValue("ic",.05),
				new DigramValue("id",.1),
				new DigramValue("if",.05),
				new DigramValue("ig",.05),
				new DigramValue("ik",.05),
				new DigramValue("il",.05),
				new DigramValue("im",.05),
				new DigramValue("in",.1),
				new DigramValue("io",.05),
				new DigramValue("ip",.05),
				new DigramValue("ir",.05), 
				new DigramValue("is",.1),
				new DigramValue("it",.1),
				new DigramValue("iv",.05),
				new DigramValue("ix",.05),
				new DigramValue("iz",.05)
			}
		},
		{
			"hk", 
			new List<DigramValue>() {
				new DigramValue("ka",.1),
				new DigramValue("ke",.1),
				new DigramValue("ki",.2),
				new DigramValue("kn",.1),
				new DigramValue("ko",.1),
				new DigramValue("ku",.1)
			}
		},
		{
			"hl", 
			new List<DigramValue>() {
				new DigramValue("la",.2),
				new DigramValue("le",.2),
				new DigramValue("li",.1),
				new DigramValue("lo",.1),
				new DigramValue("lu",.1)
			}
		},
		{
			"ho", 
			new List<DigramValue>() {
				new DigramValue("ob",.05),
				new DigramValue("oc",.05),
				new DigramValue("od",.1),
				new DigramValue("of",.05),
				new DigramValue("og",.05),
				new DigramValue("ok",.05),
				new DigramValue("ol",.05),
				new DigramValue("on",.1),
				new DigramValue("oo",.05),
				new DigramValue("op",.05),
				new DigramValue("or",.1),
				new DigramValue("os",.1),
				new DigramValue("ot",.05),
				new DigramValue("ov",.05),
				new DigramValue("ow",.05),
				new DigramValue("oy",.05)
			}
		},
		{
			"hr", 
			new List<DigramValue>() {
				new DigramValue("ra",.1),
				new DigramValue("re",.05),
				new DigramValue("ri",.05),
				new DigramValue("ro",.05),
				new DigramValue("ru",.05)
			}
		},
		{
			"hu", 
			new List<DigramValue>() {
				new DigramValue("ub",.1),
				new DigramValue("uc",.05),
				new DigramValue("ud",.1),
				new DigramValue("ug",.05),
				new DigramValue("ul",.1),
				new DigramValue("um",.1),
				new DigramValue("un",.1),
				new DigramValue("up",.1),
				new DigramValue("ur",.1),
				new DigramValue("us",.1),
				new DigramValue("ut",.1)
			}
		},

		{
			"ic", 
			new List<DigramValue>() {
				new DigramValue("ca",.1),
				new DigramValue("cb",.05),
				new DigramValue("ce",.1),
				new DigramValue("ch",.1),
				new DigramValue("ci",.05),
				new DigramValue("cl",.1),
				new DigramValue("ck",.1),
				new DigramValue("co",.1),
				new DigramValue("cr",.1),
				new DigramValue("cu",.05),
				new DigramValue("cw",.05),
				new DigramValue("cy",.05)
			}
		},
		{
			"id", 
			new List<DigramValue>() {
				new DigramValue("da",.1),
				new DigramValue("de",.1),
				new DigramValue("df",.05),
				new DigramValue("dg",.05),
				new DigramValue("di",.1),
				new DigramValue("dj",.05),
				new DigramValue("dl",.1),
				new DigramValue("do",.1),
				new DigramValue("dr",.1),
				new DigramValue("dq",.05),
				new DigramValue("dt",.1),
				new DigramValue("dv",.05)
			}
		},
		{
			"if", 
			new List<DigramValue>() {
				new DigramValue("fa",.2),
				new DigramValue("fe",.1),
				new DigramValue("ff",.1),
				new DigramValue("fh",.1),
				new DigramValue("fi",.1),
				new DigramValue("fl",.1),
				new DigramValue("fo",.1),
				new DigramValue("fr",.1),
				new DigramValue("fu",.1)
			}
		},
		{
			"ig", 
			new List<DigramValue>() {
				new DigramValue("ga",.1),
				new DigramValue("ge",.1),
				new DigramValue("gg",.1),
				new DigramValue("gh",.1),
				new DigramValue("gi",.1),
				new DigramValue("gl",.1),
				new DigramValue("gn",.05),
				new DigramValue("go",.1),
				new DigramValue("gr",.1),
				new DigramValue("gu",.1),
				new DigramValue("gy",.05)
			}
		},
		{
			"ik", 
			new List<DigramValue>() {
				new DigramValue("ka",.1),
				new DigramValue("ke",.1),
				new DigramValue("ki",.2),
				new DigramValue("kl",.1),
				new DigramValue("kn",.1),
				new DigramValue("ko",.1),
				new DigramValue("kr",.1),
				new DigramValue("ku",.1),
				new DigramValue("kv",.1)
			}
		},
		{
			"il", 
			new List<DigramValue>() {
				new DigramValue("la",.2),
				new DigramValue("le",.2),
				new DigramValue("li",.1),
				new DigramValue("ll",.1),
				new DigramValue("lk",.1),
				new DigramValue("lm",.1),
				new DigramValue("lo",.1),
				new DigramValue("lu",.1)
			}
		},
		{
			"im", 
			new List<DigramValue>() {
				new DigramValue("ma",.1),
				new DigramValue("me",.2),
				new DigramValue("mi",.1),
				new DigramValue("mo",.2),
				new DigramValue("mp",.1),
				new DigramValue("mr",.1),
				new DigramValue("mu",.1),
				new DigramValue("mz",.1)
			}
		},
		{
			"in", 
			new List<DigramValue>() {
				new DigramValue("na",.1),
				new DigramValue("nc",.05),
				new DigramValue("nd",.05),
				new DigramValue("ne",.1),
				new DigramValue("ni",.1),
				new DigramValue("nj",.05),
				new DigramValue("nk",.1),
				new DigramValue("nn",.1),
				new DigramValue("no",.1),
				new DigramValue("ns",.1),
				new DigramValue("nt",.1),
				new DigramValue("nu",.1)
			}
		},
		{
			"io", 
			new List<DigramValue>() {
				new DigramValue("ob",.05),
				new DigramValue("oc",.05),
				new DigramValue("od",.1),
				new DigramValue("ol",.05),
				new DigramValue("on",.1),
				new DigramValue("or",.1),
				new DigramValue("os",.1),
				new DigramValue("ot",.05),
				new DigramValue("ov",.05)
			}
		},
		{
			"ip", 
			new List<DigramValue>() {
				new DigramValue("pa",.1),
				new DigramValue("pe",.1),
				new DigramValue("ph",.1),
				new DigramValue("pl",.1),
				new DigramValue("po",.1),
				new DigramValue("pr",.1),
				new DigramValue("pu",.1),
				new DigramValue("py",.2)
			}
		},
		{
			"ir", 
			new List<DigramValue>() {
				new DigramValue("ra",.1),
				new DigramValue("rc",.05),
				new DigramValue("rd",.05),
				new DigramValue("re",.05),
				new DigramValue("rg",.05),
				new DigramValue("ri",.05),
				new DigramValue("rk",.05),
				new DigramValue("rl",.05),
				new DigramValue("rm",.05),
				new DigramValue("rn",.05),
				new DigramValue("ro",.05),
				new DigramValue("rp",.05),
				new DigramValue("rr",.05),
				new DigramValue("rs",.05),
				new DigramValue("rt",.05),
				new DigramValue("ru",.05),
				new DigramValue("rv",.05),
			}
		},
		{
			"is", 
			new List<DigramValue>() {
				new DigramValue("sa",.05),
				new DigramValue("sc",.1),
				new DigramValue("se",.05),
				new DigramValue("sh",.05),
				new DigramValue("si",.05),
				new DigramValue("sj",.05),
				new DigramValue("sk",.05),
				new DigramValue("sl",.05),
				new DigramValue("sm",.05),
				new DigramValue("sn",.05),
				new DigramValue("so",.05),
				new DigramValue("sp",.05),
				new DigramValue("sq",.05),
				new DigramValue("sr",.05),
				new DigramValue("ss",.05),
				new DigramValue("st",.05),
				new DigramValue("su",.05),
				new DigramValue("sv",.05),
				new DigramValue("sy",.05)
			}
		},
		{
			"it", 
			new List<DigramValue>() {
				new DigramValue("ta",.1),
				new DigramValue("tc",.05),
				new DigramValue("te",.1),
				new DigramValue("th",.1),
				new DigramValue("ti",.1),
				new DigramValue("tl",.05),
				new DigramValue("to",.1),
				new DigramValue("tr",.1),
				new DigramValue("ts",.05), 
				new DigramValue("tt",.1),
				new DigramValue("tu",.1),
				new DigramValue("ty",.05)
			}
		},
		{
			"iv", 
			new List<DigramValue>() {
				new DigramValue("va",.1),
				new DigramValue("vb",.1),
				new DigramValue("ve",.1),
				new DigramValue("vh",.1),
				new DigramValue("vi",.1),
				new DigramValue("vj",.05),
				new DigramValue("vl",.1),
				new DigramValue("vo",.1),
				new DigramValue("vr",.05),
				new DigramValue("vu",.1),
				new DigramValue("vy",.1)
			}
		},
		{
			"ix", 
			new List<DigramValue>() {
				new DigramValue("xa",.2),
				new DigramValue("xu",.1)
			}
		},
		{
			"iz", 
			new List<DigramValue>() {
				new DigramValue("za",.1),
				new DigramValue("ze",.1),
				new DigramValue("zo",.1),
				new DigramValue("zu",.1)
			}
		},

		{
			"ja", 
			new List<DigramValue>() {
				new DigramValue("ab",.05),
				new DigramValue("ac",.05),
				new DigramValue("ad",.05),
				new DigramValue("ae",.05),
				new DigramValue("af",.05),
				new DigramValue("ag",.05),
				new DigramValue("ah",.05),
				new DigramValue("ai",.05),
				new DigramValue("ak",.05),
				new DigramValue("al",.05),
				new DigramValue("am",.05),
				new DigramValue("an",.05),
				new DigramValue("ap",.05),
				new DigramValue("ar",.05),
				new DigramValue("as",.05),
				new DigramValue("at",.05),
				new DigramValue("au",.05),
				new DigramValue("av",.05),
				new DigramValue("aw",.025),
				new DigramValue("ax",.025),
				new DigramValue("ay",.025),
				new DigramValue("az",.025)
			}
		},
		{
			"je", 
			new List<DigramValue>() {
				new DigramValue("ea",.05),
				new DigramValue("eb",.025),
				new DigramValue("ec",.05),
				new DigramValue("ed",.05),
				new DigramValue("ef",.025),
				new DigramValue("eg",.05),
				new DigramValue("eh",.025),
				new DigramValue("ei",.05),
				new DigramValue("ek",.025),
				new DigramValue("ee",.05),
				new DigramValue("el",.05),
				new DigramValue("ej",.025),
				new DigramValue("em",.05),
				new DigramValue("en",.05),
				new DigramValue("ep",.025),
				new DigramValue("eq",.025),
				new DigramValue("er",.05),
				new DigramValue("es",.05),
				new DigramValue("et",.05),
				new DigramValue("ev",.05),
				new DigramValue("ew",.05),
				new DigramValue("ex",.05),
				new DigramValue("ey",.025)
			}
		},
		{
			"ji", 
			new List<DigramValue>() {
				new DigramValue("ic",.05),
				new DigramValue("id",.1),
				new DigramValue("if",.05),
				new DigramValue("ig",.05),
				new DigramValue("ik",.05),
				new DigramValue("il",.05),
				new DigramValue("im",.05),
				new DigramValue("in",.1),
				new DigramValue("io",.05),
				new DigramValue("ip",.05),
				new DigramValue("ir",.05), 
				new DigramValue("is",.1),
				new DigramValue("it",.1),
				new DigramValue("iv",.05),
				new DigramValue("ix",.05),
				new DigramValue("iz",.05)
			}
		},
		{
			"jo", 
			new List<DigramValue>() {
				new DigramValue("ob",.05),
				new DigramValue("oc",.05),
				new DigramValue("od",.1),
				new DigramValue("of",.05),
				new DigramValue("og",.05),
				new DigramValue("ok",.05),
				new DigramValue("ol",.05),
				new DigramValue("on",.1),
				new DigramValue("oo",.05),
				new DigramValue("op",.05),
				new DigramValue("or",.1),
				new DigramValue("os",.1),
				new DigramValue("ot",.05),
				new DigramValue("ov",.05),
				new DigramValue("ow",.05),
				new DigramValue("oy",.05)
			}
		},
		{
			"ju", 
			new List<DigramValue>() {
				new DigramValue("ub",.1),
				new DigramValue("uc",.05),
				new DigramValue("ud",.1),
				new DigramValue("ug",.05),
				new DigramValue("ul",.1),
				new DigramValue("um",.1),
				new DigramValue("un",.1),
				new DigramValue("up",.1),
				new DigramValue("ur",.1),
				new DigramValue("us",.1),
				new DigramValue("ut",.1)
			}
		},

		{
			"ka", 
			new List<DigramValue>() {
				new DigramValue("ab",.05),
				new DigramValue("ac",.05),
				new DigramValue("ad",.05),
				new DigramValue("ae",.05),
				new DigramValue("af",.05),
				new DigramValue("ag",.05),
				new DigramValue("ah",.05),
				new DigramValue("ai",.05),
				new DigramValue("ak",.05),
				new DigramValue("al",.05),
				new DigramValue("am",.05),
				new DigramValue("an",.05),
				new DigramValue("ap",.05),
				new DigramValue("ar",.05),
				new DigramValue("as",.05),
				new DigramValue("at",.05),
				new DigramValue("au",.05),
				new DigramValue("av",.05),
				new DigramValue("aw",.025),
				new DigramValue("ax",.025),
				new DigramValue("ay",.025),
				new DigramValue("az",.025)
			}
		},
		{
			"ke", 
			new List<DigramValue>() {
				new DigramValue("ea",.05),
				new DigramValue("eb",.025),
				new DigramValue("ec",.05),
				new DigramValue("ed",.05),
				new DigramValue("ef",.025),
				new DigramValue("eg",.05),
				new DigramValue("eh",.025),
				new DigramValue("ei",.05),
				new DigramValue("ek",.025),
				new DigramValue("ee",.05),
				new DigramValue("el",.05),
				new DigramValue("ej",.025),
				new DigramValue("em",.05),
				new DigramValue("en",.05),
				new DigramValue("ep",.025),
				new DigramValue("eq",.025),
				new DigramValue("er",.05),
				new DigramValue("es",.05),
				new DigramValue("et",.05),
				new DigramValue("ev",.05),
				new DigramValue("ew",.05),
				new DigramValue("ex",.05),
				new DigramValue("ey",.025)
			}
		},
		{
			"ki", 
			new List<DigramValue>() {
				new DigramValue("ic",.05),
				new DigramValue("id",.1),
				new DigramValue("if",.05),
				new DigramValue("ig",.05),
				new DigramValue("ik",.05),
				new DigramValue("il",.05),
				new DigramValue("im",.05),
				new DigramValue("in",.1),
				new DigramValue("io",.05),
				new DigramValue("ip",.05),
				new DigramValue("ir",.05), 
				new DigramValue("is",.1),
				new DigramValue("it",.1),
				new DigramValue("iv",.05),
				new DigramValue("ix",.05),
				new DigramValue("iz",.05)
			}
		},
		{
			"kl", 
			new List<DigramValue>() {
				new DigramValue("la",.2),
				new DigramValue("le",.2),
				new DigramValue("li",.1),
				new DigramValue("lo",.1),
				new DigramValue("lu",.1)
			}
		},
		{
			"kn", 
			new List<DigramValue>() {
				new DigramValue("na",.1),
				new DigramValue("ne",.1),
				new DigramValue("ni",.1),
				new DigramValue("no",.1),
				new DigramValue("nu",.1)
			}
		},
		{
			"ko", 
			new List<DigramValue>() {
				new DigramValue("ob",.05),
				new DigramValue("oc",.05),
				new DigramValue("od",.1),
				new DigramValue("of",.05),
				new DigramValue("og",.05),
				new DigramValue("ok",.05),
				new DigramValue("ol",.05),
				new DigramValue("on",.1),
				new DigramValue("oo",.05),
				new DigramValue("op",.05),
				new DigramValue("or",.1),
				new DigramValue("os",.1),
				new DigramValue("ot",.05),
				new DigramValue("ov",.05),
				new DigramValue("ow",.05),
				new DigramValue("oy",.05)
			}
		},
		{
			"kr", 
			new List<DigramValue>() {
				new DigramValue("ra",.1),
				new DigramValue("re",.05),
				new DigramValue("ri",.05),
				new DigramValue("ro",.05),
				new DigramValue("ru",.05)
			}
		},
		{
			"ku", 
			new List<DigramValue>() {
				new DigramValue("ub",.1),
				new DigramValue("uc",.05),
				new DigramValue("ud",.1),
				new DigramValue("ug",.05),
				new DigramValue("ul",.1),
				new DigramValue("um",.1),
				new DigramValue("un",.1),
				new DigramValue("up",.1),
				new DigramValue("ur",.1),
				new DigramValue("us",.1),
				new DigramValue("ut",.1)
			}
		},
		{
			"kv", 
			new List<DigramValue>() {
				new DigramValue("va",.1),
				new DigramValue("ve",.1),
				new DigramValue("vo",.1)
			}
		},

		{
			"la", 
			new List<DigramValue>() {
				new DigramValue("ab",.05),
				new DigramValue("ac",.05),
				new DigramValue("ad",.05),
				new DigramValue("ae",.05),
				new DigramValue("af",.05),
				new DigramValue("ag",.05),
				new DigramValue("ah",.05),
				new DigramValue("ai",.05),
				new DigramValue("ak",.05),
				new DigramValue("al",.05),
				new DigramValue("am",.05),
				new DigramValue("an",.05),
				new DigramValue("ap",.05),
				new DigramValue("ar",.05),
				new DigramValue("as",.05),
				new DigramValue("at",.05),
				new DigramValue("au",.05),
				new DigramValue("av",.05),
				new DigramValue("aw",.025),
				new DigramValue("ax",.025),
				new DigramValue("ay",.025),
				new DigramValue("az",.025)
			}
		},
		{
			"le", 
			new List<DigramValue>() {
				new DigramValue("ea",.05),
				new DigramValue("eb",.025),
				new DigramValue("ec",.05),
				new DigramValue("ed",.05),
				new DigramValue("ef",.025),
				new DigramValue("eg",.05),
				new DigramValue("eh",.025),
				new DigramValue("ei",.05),
				new DigramValue("ek",.025),
				new DigramValue("ee",.05),
				new DigramValue("el",.05),
				new DigramValue("ej",.025),
				new DigramValue("em",.05),
				new DigramValue("en",.05),
				new DigramValue("ep",.025),
				new DigramValue("eq",.025),
				new DigramValue("er",.05),
				new DigramValue("es",.05),
				new DigramValue("et",.05),
				new DigramValue("ev",.05),
				new DigramValue("ew",.05),
				new DigramValue("ex",.05),
				new DigramValue("ey",.025)
			}
		},
		{
			"li", 
			new List<DigramValue>() {
				new DigramValue("ic",.05),
				new DigramValue("id",.1),
				new DigramValue("if",.05),
				new DigramValue("ig",.05),
				new DigramValue("ik",.05),
				new DigramValue("il",.05),
				new DigramValue("im",.05),
				new DigramValue("in",.1),
				new DigramValue("io",.05),
				new DigramValue("ip",.05),
				new DigramValue("ir",.05), 
				new DigramValue("is",.1),
				new DigramValue("it",.1),
				new DigramValue("iv",.05),
				new DigramValue("ix",.05),
				new DigramValue("iz",.05)
			}
		},
		{
			"ll", 
			new List<DigramValue>() {
				new DigramValue("la",.2),
				new DigramValue("le",.2),
				new DigramValue("li",.1),
				new DigramValue("lo",.1),
				new DigramValue("lu",.1)
			}
		},
		{
			"lk", 
			new List<DigramValue>() {
				new DigramValue("ka",.1),
				new DigramValue("ke",.1),
				new DigramValue("ki",.2),
				new DigramValue("ko",.1),
				new DigramValue("ku",.1)
			}
		},
		{
			"lm", 
			new List<DigramValue>() {
				new DigramValue("ma",.1),
				new DigramValue("me",.2),
				new DigramValue("mi",.1),
				new DigramValue("mo",.2),
				new DigramValue("mu",.1)
			}
		},
		{
			"lo", 
			new List<DigramValue>() {
				new DigramValue("ob",.05),
				new DigramValue("oc",.05),
				new DigramValue("od",.1),
				new DigramValue("of",.05),
				new DigramValue("og",.05),
				new DigramValue("ok",.05),
				new DigramValue("ol",.05),
				new DigramValue("on",.1),
				new DigramValue("oo",.05),
				new DigramValue("op",.05),
				new DigramValue("or",.1),
				new DigramValue("os",.1),
				new DigramValue("ot",.05),
				new DigramValue("ov",.05),
				new DigramValue("ow",.05),
				new DigramValue("oy",.05)
			}
		},
		{
			"lu", 
			new List<DigramValue>() {
				new DigramValue("ub",.1),
				new DigramValue("uc",.05),
				new DigramValue("ud",.1),
				new DigramValue("ug",.05),
				new DigramValue("ul",.1),
				new DigramValue("um",.1),
				new DigramValue("un",.1),
				new DigramValue("up",.1),
				new DigramValue("ur",.1),
				new DigramValue("us",.1),
				new DigramValue("ut",.1)
			}
		},

		{
			"ma", 
			new List<DigramValue>() {
				new DigramValue("ab",.05),
				new DigramValue("ac",.05),
				new DigramValue("ad",.05),
				new DigramValue("ae",.05),
				new DigramValue("af",.05),
				new DigramValue("ag",.05),
				new DigramValue("ah",.05),
				new DigramValue("ai",.05),
				new DigramValue("ak",.05),
				new DigramValue("al",.05),
				new DigramValue("am",.05),
				new DigramValue("an",.05),
				new DigramValue("ap",.05),
				new DigramValue("ar",.05),
				new DigramValue("as",.05),
				new DigramValue("at",.05),
				new DigramValue("au",.05),
				new DigramValue("av",.05),
				new DigramValue("aw",.025),
				new DigramValue("ax",.025),
				new DigramValue("ay",.025),
				new DigramValue("az",.025)
			}
		},
		{
			"me", 
			new List<DigramValue>() {
				new DigramValue("ea",.05),
				new DigramValue("eb",.025),
				new DigramValue("ec",.05),
				new DigramValue("ed",.05),
				new DigramValue("ef",.025),
				new DigramValue("eg",.05),
				new DigramValue("eh",.025),
				new DigramValue("ei",.05),
				new DigramValue("ek",.025),
				new DigramValue("ee",.05),
				new DigramValue("el",.05),
				new DigramValue("ej",.025),
				new DigramValue("em",.05),
				new DigramValue("en",.05),
				new DigramValue("ep",.025),
				new DigramValue("eq",.025),
				new DigramValue("er",.05),
				new DigramValue("es",.05),
				new DigramValue("et",.05),
				new DigramValue("ev",.05),
				new DigramValue("ew",.05),
				new DigramValue("ex",.05),
				new DigramValue("ey",.025)
			}
		},
		{
			"mi", 
			new List<DigramValue>() {
				new DigramValue("ic",.05),
				new DigramValue("id",.1),
				new DigramValue("if",.05),
				new DigramValue("ig",.05),
				new DigramValue("ik",.05),
				new DigramValue("il",.05),
				new DigramValue("im",.05),
				new DigramValue("in",.1),
				new DigramValue("io",.05),
				new DigramValue("ip",.05),
				new DigramValue("ir",.05), 
				new DigramValue("is",.1),
				new DigramValue("it",.1),
				new DigramValue("iv",.05),
				new DigramValue("ix",.05),
				new DigramValue("iz",.05)
			}
		},
		{
			"mo", 
			new List<DigramValue>() {
				new DigramValue("ob",.05),
				new DigramValue("oc",.05),
				new DigramValue("od",.1),
				new DigramValue("of",.05),
				new DigramValue("og",.05),
				new DigramValue("ok",.05),
				new DigramValue("ol",.05),
				new DigramValue("on",.1),
				new DigramValue("oo",.05),
				new DigramValue("op",.05),
				new DigramValue("or",.1),
				new DigramValue("os",.1),
				new DigramValue("ot",.05),
				new DigramValue("ov",.05),
				new DigramValue("ow",.05),
				new DigramValue("oy",.05)
			}
		},
		{
			"mp", 
			new List<DigramValue>() {
				new DigramValue("pa",.1),
				new DigramValue("pe",.1),
				new DigramValue("po",.1),
				new DigramValue("pr",.1),
				new DigramValue("pu",.1),
				new DigramValue("py",.2)
			}
		},
		{
			"mr", 
			new List<DigramValue>() {
				new DigramValue("re",.05),
				new DigramValue("ri",.05),
				new DigramValue("ro",.05),
				new DigramValue("ru",.05)
			}
		},
		{
			"mu", 
			new List<DigramValue>() {
				new DigramValue("ub",.1),
				new DigramValue("uc",.05),
				new DigramValue("ud",.1),
				new DigramValue("ug",.05),
				new DigramValue("ul",.1),
				new DigramValue("um",.1),
				new DigramValue("un",.1),
				new DigramValue("up",.1),
				new DigramValue("ur",.1),
				new DigramValue("us",.1),
				new DigramValue("ut",.1)
			}
		},
		{
			"mz", 
			new List<DigramValue>() {
				new DigramValue("za",.1)
			}
		},
		{
			"na", 
			new List<DigramValue>() {
				new DigramValue("ab",.05),
				new DigramValue("ac",.05),
				new DigramValue("ad",.05),
				new DigramValue("ae",.05),
				new DigramValue("af",.05),
				new DigramValue("ag",.05),
				new DigramValue("ah",.05),
				new DigramValue("ai",.05),
				new DigramValue("ak",.05),
				new DigramValue("al",.05),
				new DigramValue("am",.05),
				new DigramValue("an",.05),
				new DigramValue("ap",.05),
				new DigramValue("ar",.05),
				new DigramValue("as",.05),
				new DigramValue("at",.05),
				new DigramValue("au",.05),
				new DigramValue("av",.05),
				new DigramValue("aw",.025),
				new DigramValue("ax",.025),
				new DigramValue("ay",.025),
				new DigramValue("az",.025)
			}
		},
		{
			"nc", 
			new List<DigramValue>() {
				new DigramValue("ca",.1),
				new DigramValue("ce",.1),
				new DigramValue("cl",.1),
				new DigramValue("co",.1),
				new DigramValue("cr",.1),
				new DigramValue("cy",.05)
			}
		},
		{
			"nd", 
			new List<DigramValue>() {
				new DigramValue("da",.1),
				new DigramValue("de",.1),
				new DigramValue("di",.1),
				new DigramValue("do",.1)
			}
		},
		{
			"ne", 
			new List<DigramValue>() {
				new DigramValue("ea",.05),
				new DigramValue("eb",.025),
				new DigramValue("ec",.05),
				new DigramValue("ed",.05),
				new DigramValue("ef",.025),
				new DigramValue("eg",.05),
				new DigramValue("eh",.025),
				new DigramValue("ei",.05),
				new DigramValue("ek",.025),
				new DigramValue("ee",.05),
				new DigramValue("el",.05),
				new DigramValue("ej",.025),
				new DigramValue("em",.05),
				new DigramValue("en",.05),
				new DigramValue("ep",.025),
				new DigramValue("eq",.025),
				new DigramValue("er",.05),
				new DigramValue("es",.05),
				new DigramValue("et",.05),
				new DigramValue("ev",.05),
				new DigramValue("ew",.05),
				new DigramValue("ex",.05),
				new DigramValue("ey",.025)
			}
		},
		{
			"ni", 
			new List<DigramValue>() {
				new DigramValue("ic",.05),
				new DigramValue("id",.1),
				new DigramValue("if",.05),
				new DigramValue("ig",.05),
				new DigramValue("ik",.05),
				new DigramValue("il",.05),
				new DigramValue("im",.05),
				new DigramValue("in",.1),
				new DigramValue("io",.05),
				new DigramValue("ip",.05),
				new DigramValue("ir",.05),
				new DigramValue("is",.1),
				new DigramValue("it",.1),
				new DigramValue("iv",.05),
				new DigramValue("ix",.05),
				new DigramValue("iz",.05)
			}
		},
		{
			"nj", 
			new List<DigramValue>() {
				new DigramValue("ja",.2),
				new DigramValue("je",.2),
				new DigramValue("ji",.2),
				new DigramValue("jo",.2),
				new DigramValue("ju",.2)
			}
		},
		{
			"nk", 
			new List<DigramValue>() {
				new DigramValue("ka",.1),
				new DigramValue("ke",.1),
				new DigramValue("ki",.2),
				new DigramValue("ko",.1)
			}
		},
		{
			"nn", 
			new List<DigramValue>() {
				new DigramValue("na",.1),
				new DigramValue("ne",.1),
				new DigramValue("ni",.1),
				new DigramValue("no",.1),
				new DigramValue("nu",.1)
			}
		},
		{
			"no", 
			new List<DigramValue>() {
				new DigramValue("ob",.05),
				new DigramValue("oc",.05),
				new DigramValue("od",.1),
				new DigramValue("of",.05),
				new DigramValue("og",.05),
				new DigramValue("ok",.05),
				new DigramValue("ol",.05),
				new DigramValue("on",.1),
				new DigramValue("oo",.05),
				new DigramValue("op",.05),
				new DigramValue("or",.1),
				new DigramValue("os",.1),
				new DigramValue("ot",.05),
				new DigramValue("ov",.05),
				new DigramValue("ow",.05),
				new DigramValue("oy",.05)
			}
		},
		{
			"ns", 
			new List<DigramValue>() {
				new DigramValue("sa",.05),
				new DigramValue("se",.05),
				new DigramValue("so",.05),
				new DigramValue("sp",.05),
				new DigramValue("st",.05),
				new DigramValue("su",.05),
				new DigramValue("sy",.05)
			}
		},
		{
			"nt", 
			new List<DigramValue>() {
				new DigramValue("ta",.1),
				new DigramValue("tc",.05),
				new DigramValue("te",.1),
				new DigramValue("th",.1),
				new DigramValue("ti",.1),
				new DigramValue("tl",.05),
				new DigramValue("to",.1),
				new DigramValue("tr",.1),
				new DigramValue("ts",.05),
				new DigramValue("tt",.1),
				new DigramValue("tu",.1),
				new DigramValue("ty",.05)
			}
		},
		{
			"nu", 
			new List<DigramValue>() {
				new DigramValue("ub",.1),
				new DigramValue("uc",.05),
				new DigramValue("ud",.1),
				new DigramValue("ug",.05),
				new DigramValue("ul",.1),
				new DigramValue("um",.1),
				new DigramValue("un",.1),
				new DigramValue("up",.1),
				new DigramValue("ur",.1),
				new DigramValue("us",.1),
				new DigramValue("ut",.1)
			}
		},

		{
			"ob", 
			new List<DigramValue>() {
				new DigramValue("ba",.1),
				new DigramValue("be",.1),
				new DigramValue("bf",.1),
				new DigramValue("bh",.1),
				new DigramValue("bi",.1),
				new DigramValue("bl",.1),
				new DigramValue("bo",.1),
				new DigramValue("br",.1),
				new DigramValue("bu",.1),
				new DigramValue("by",.1)
			}
		},
		{
			"oc", 
			new List<DigramValue>() {
				new DigramValue("ca",.1),
				new DigramValue("cb",.05),
				new DigramValue("cc",.05),
				new DigramValue("ce",.1),
				new DigramValue("ch",.1),
				new DigramValue("ci",.05),
				new DigramValue("cl",.1),
				new DigramValue("ck",.1),
				new DigramValue("co",.1),
				new DigramValue("cr",.1),
				new DigramValue("cu",.05),
				new DigramValue("cw",.05),
				new DigramValue("cy",.05)
			}
		},
		{
			"od", 
			new List<DigramValue>() {
				new DigramValue("da",.1),
				new DigramValue("de",.1),
				new DigramValue("df",.05),
				new DigramValue("dg",.05),
				new DigramValue("di",.1),
				new DigramValue("dj",.05),
				new DigramValue("dl",.1),
				new DigramValue("do",.1),
				new DigramValue("dr",.1),
				new DigramValue("dq",.05),
				new DigramValue("dt",.1),
				new DigramValue("dv",.05)
			}
		},
		{
			"of", 
			new List<DigramValue>() {
				new DigramValue("fa",.2),
				new DigramValue("fe",.1),
				new DigramValue("ff",.1),
				new DigramValue("fh",.1),
				new DigramValue("fi",.1),
				new DigramValue("fl",.1),
				new DigramValue("fo",.1),
				new DigramValue("fr",.1),
				new DigramValue("fu",.1)
			}
		},
		{
			"og", 
			new List<DigramValue>() {
				new DigramValue("ga",.1),
				new DigramValue("ge",.1),
				new DigramValue("gg",.1),
				new DigramValue("gh",.1),
				new DigramValue("gi",.1),
				new DigramValue("gl",.1),
				new DigramValue("gn",.05),
				new DigramValue("go",.1),
				new DigramValue("gr",.1),
				new DigramValue("gu",.1),
				new DigramValue("gy",.05)
			}
		},
		{
			"ok", 
			new List<DigramValue>() {
				new DigramValue("ka",.1),
				new DigramValue("ke",.1),
				new DigramValue("ki",.2),
				new DigramValue("kl",.1),
				new DigramValue("kn",.1),
				new DigramValue("ko",.1),
				new DigramValue("kr",.1),
				new DigramValue("ku",.1),
				new DigramValue("kv",.1)
			}
		},
		{
			"ol", 
			new List<DigramValue>() {
				new DigramValue("la",.2),
				new DigramValue("le",.2),
				new DigramValue("li",.1),
				new DigramValue("ll",.1),
				new DigramValue("lk",.1),
				new DigramValue("lm",.1),
				new DigramValue("lo",.1),
				new DigramValue("lu",.1)
			}
		},
		{
			"on", 
			new List<DigramValue>() {
				new DigramValue("na",.1),
				new DigramValue("nc",.05),
				new DigramValue("nd",.05),
				new DigramValue("ne",.1),
				new DigramValue("ni",.1),
				new DigramValue("nj",.05),
				new DigramValue("nk",.1),
				new DigramValue("nn",.1),
				new DigramValue("no",.1),
				new DigramValue("ns",.1),
				new DigramValue("nt",.1),
				new DigramValue("nu",.1)
			}
		},
		{
			"oo", 
			new List<DigramValue>() {
				new DigramValue("ob",.05),
				new DigramValue("oc",.05),
				new DigramValue("od",.1),
				new DigramValue("of",.05),
				new DigramValue("og",.05),
				new DigramValue("ok",.05),
				new DigramValue("ol",.05),
				new DigramValue("on",.1),
				new DigramValue("op",.05),
				new DigramValue("or",.1),
				new DigramValue("ot",.05),
				new DigramValue("ov",.05),
				new DigramValue("ow",.05),
				new DigramValue("oy",.05)
			}
		},
		{
			"op", 
			new List<DigramValue>() {
				new DigramValue("pa",.1),
				new DigramValue("pe",.1),
				new DigramValue("ph",.1),
				new DigramValue("pl",.1),
				new DigramValue("po",.1),
				new DigramValue("pr",.1),
				new DigramValue("pu",.1),
				new DigramValue("py",.2)
			}
		},
		{
			"or", 
			new List<DigramValue>() {
				new DigramValue("ra",.1),
				new DigramValue("rc",.05),
				new DigramValue("rd",.05),
				new DigramValue("re",.05),
				new DigramValue("rg",.05),
				new DigramValue("ri",.05),
				new DigramValue("rk",.05),
				new DigramValue("rl",.05),
				new DigramValue("rm",.05),
				new DigramValue("rn",.05),
				new DigramValue("ro",.05),
				new DigramValue("rp",.05),
				new DigramValue("rr",.05),
				new DigramValue("rs",.05),
				new DigramValue("rt",.05),
				new DigramValue("ru",.05),
				new DigramValue("rv",.05),
				new DigramValue("rw",.05),
				new DigramValue("rx",.05)
			}
		},
		{
			"os", 
			new List<DigramValue>() {
				new DigramValue("sa",.05),
				new DigramValue("sc",.1),
				new DigramValue("se",.05),
				new DigramValue("sh",.05),
				new DigramValue("si",.05),
				new DigramValue("sj",.05),
				new DigramValue("sk",.05),
				new DigramValue("sl",.05),
				new DigramValue("sm",.05),
				new DigramValue("sn",.05),
				new DigramValue("so",.05),
				new DigramValue("sp",.05),
				new DigramValue("sq",.05),
				new DigramValue("sr",.05),
				new DigramValue("ss",.05),
				new DigramValue("st",.05),
				new DigramValue("su",.05),
				new DigramValue("sv",.05),
				new DigramValue("sy",.05)
			}
		},
		{
			"ot", 
			new List<DigramValue>() {
				new DigramValue("ta",.1),
				new DigramValue("tc",.05),
				new DigramValue("te",.1),
				new DigramValue("th",.1),
				new DigramValue("ti",.1),
				new DigramValue("to",.1),
				new DigramValue("tr",.1),
				new DigramValue("ts",.05),
				new DigramValue("tt",.1),
				new DigramValue("tu",.1),
				new DigramValue("ty",.05)
			}
		},
		{
			"ov", 
			new List<DigramValue>() {
				new DigramValue("va",.1),
				new DigramValue("vb",.1),
				new DigramValue("ve",.1),
				new DigramValue("vh",.1),
				new DigramValue("vi",.1),
				new DigramValue("vj",.05),
				new DigramValue("vl",.1),
				new DigramValue("vo",.1),
				new DigramValue("vr",.05),
				new DigramValue("vu",.1),
				new DigramValue("vy",.1)
			}
		},
		{
			"ow", 
			new List<DigramValue>() {
				new DigramValue("wa",.2),
				new DigramValue("we",.2),
				new DigramValue("wh",.1),
				new DigramValue("wi",.1),
				new DigramValue("wo",.1),
				new DigramValue("wr",.2),
				new DigramValue("wu",.1)
			}
		},
		{
			"oy", 
			new List<DigramValue>() {
				new DigramValue("ya",.1),
				new DigramValue("yc",.1),
				new DigramValue("ye",.1),
				new DigramValue("yi",.1),
				new DigramValue("yr",.1),
				new DigramValue("yt",.1),
				new DigramValue("yu",.1)
			}
		},

		{
			"pa", 
			new List<DigramValue>() {
				new DigramValue("ab",.05),
				new DigramValue("ac",.05),
				new DigramValue("ad",.05),
				new DigramValue("ae",.05),
				new DigramValue("af",.05),
				new DigramValue("ag",.05),
				new DigramValue("ah",.05),
				new DigramValue("ai",.05),
				new DigramValue("ak",.05),
				new DigramValue("al",.05),
				new DigramValue("am",.05),
				new DigramValue("an",.05),
				new DigramValue("ap",.05),
				new DigramValue("ar",.05),
				new DigramValue("as",.05),
				new DigramValue("at",.05),
				new DigramValue("au",.05),
				new DigramValue("av",.05),
				new DigramValue("aw",.025),
				new DigramValue("ax",.025),
				new DigramValue("ay",.025),
				new DigramValue("az",.025)
			}
		},
		{
			"pe", 
			new List<DigramValue>() {
				new DigramValue("ea",.05),
				new DigramValue("eb",.025),
				new DigramValue("ec",.05),
				new DigramValue("ed",.05),
				new DigramValue("ef",.025),
				new DigramValue("eg",.05),
				new DigramValue("eh",.025),
				new DigramValue("ei",.05),
				new DigramValue("ek",.025),
				new DigramValue("ee",.05),
				new DigramValue("el",.05),
				new DigramValue("ej",.025),
				new DigramValue("em",.05),
				new DigramValue("en",.05),
				new DigramValue("ep",.025),
				new DigramValue("eq",.025),
				new DigramValue("er",.05),
				new DigramValue("es",.05),
				new DigramValue("et",.05),
				new DigramValue("ev",.05),
				new DigramValue("ew",.05),
				new DigramValue("ex",.05),
				new DigramValue("ey",.025)
			}
		},
		{
			"ph", 
			new List<DigramValue>() {
				new DigramValue("ha",.2),
				new DigramValue("he",.1),
				new DigramValue("hi",.1),
				new DigramValue("ho",.2),
				new DigramValue("hu",.1)
			}
		},
		{
			"pl", 
			new List<DigramValue>() {
				new DigramValue("la",.2),
				new DigramValue("le",.2),
				new DigramValue("li",.1),
				new DigramValue("lo",.1),
				new DigramValue("lu",.1)
			}
		},
		{
			"pn", 
			new List<DigramValue>() {
				new DigramValue("na",.1),
				new DigramValue("ne",.1),
				new DigramValue("ni",.1),
				new DigramValue("no",.1),
				new DigramValue("nu",.1)
			}
		},
		{
			"po", 
			new List<DigramValue>() {
				new DigramValue("ob",.05),
				new DigramValue("oc",.05),
				new DigramValue("od",.1),
				new DigramValue("of",.05),
				new DigramValue("og",.05),
				new DigramValue("ok",.05),
				new DigramValue("ol",.05),
				new DigramValue("on",.1),
				new DigramValue("oo",.05),
				new DigramValue("op",.05),
				new DigramValue("or",.1),
				new DigramValue("os",.1),
				new DigramValue("ot",.05),
				new DigramValue("ov",.05),
				new DigramValue("ow",.05),
				new DigramValue("oy",.05)
			}
		},
		{
			"pr", 
			new List<DigramValue>() {
				new DigramValue("ra",.1),
				new DigramValue("re",.05),
				new DigramValue("ri",.05),
				new DigramValue("ro",.05),
				new DigramValue("ru",.05),
			}
		},
		{
			"pu", 
			new List<DigramValue>() {
				new DigramValue("ub",.1),
				new DigramValue("uc",.05),
				new DigramValue("ud",.1),
				new DigramValue("ug",.05),
				new DigramValue("ul",.1),
				new DigramValue("um",.1),
				new DigramValue("un",.1),
				new DigramValue("up",.1),
				new DigramValue("ur",.1),
				new DigramValue("us",.1),
				new DigramValue("ut",.1)
			}
		},
		{
			"py", 
			new List<DigramValue>() {
				new DigramValue("ya",.1),
				new DigramValue("ye",.1),
				new DigramValue("yi",.1),
				new DigramValue("yo",.1),
				new DigramValue("yr",.1),
				new DigramValue("yt",.1),
				new DigramValue("yu",.1),
				new DigramValue("yy",.1)
			}
		},

		{
			"qa", 
			new List<DigramValue>() {
				new DigramValue("ab",.05),
				new DigramValue("ac",.05),
				new DigramValue("ad",.05),
				new DigramValue("ae",.05),
				new DigramValue("af",.05),
				new DigramValue("ag",.05),
				new DigramValue("ah",.05),
				new DigramValue("ai",.05),
				new DigramValue("ak",.05),
				new DigramValue("al",.05),
				new DigramValue("am",.05),
				new DigramValue("an",.05),
				new DigramValue("ap",.05),
				new DigramValue("ar",.05),
				new DigramValue("as",.05),
				new DigramValue("at",.05),
				new DigramValue("au",.05),
				new DigramValue("av",.05),
				new DigramValue("aw",.025),
				new DigramValue("ax",.025),
				new DigramValue("ay",.025),
				new DigramValue("az",.025)
			}
		},
		{
			"qu", 
			new List<DigramValue>() {
				new DigramValue("ub",.1),
				new DigramValue("uc",.05),
				new DigramValue("ud",.1),
				new DigramValue("ug",.05),
				new DigramValue("ul",.1),
				new DigramValue("um",.1),
				new DigramValue("un",.1),
				new DigramValue("up",.1),
				new DigramValue("ur",.1),
				new DigramValue("us",.1),
				new DigramValue("ut",.1)
			}
		},

		{
			"ra", 
			new List<DigramValue>() {
				new DigramValue("ab",.05),
				new DigramValue("ac",.05),
				new DigramValue("ad",.05),
				new DigramValue("ae",.05),
				new DigramValue("af",.05),
				new DigramValue("ag",.05),
				new DigramValue("ah",.05),
				new DigramValue("ai",.05),
				new DigramValue("ak",.05),
				new DigramValue("al",.05),
				new DigramValue("am",.05),
				new DigramValue("an",.05),
				new DigramValue("ap",.05),
				new DigramValue("ar",.05),
				new DigramValue("as",.05),
				new DigramValue("at",.05),
				new DigramValue("au",.05),
				new DigramValue("av",.05),
				new DigramValue("aw",.025),
				new DigramValue("ax",.025),
				new DigramValue("ay",.025),
				new DigramValue("az",.025)
			}
		},
		{
			"rc", 
			new List<DigramValue>() {
				new DigramValue("ca",.1),
				new DigramValue("ce",.1),
				new DigramValue("ch",.1),
				new DigramValue("ci",.05),
				new DigramValue("co",.1),
				new DigramValue("cu",.05),
				new DigramValue("cy",.05)
			}
		},
		{
			"rd", 
			new List<DigramValue>() {
				new DigramValue("da",.1),
				new DigramValue("de",.1),
				new DigramValue("df",.05),
				new DigramValue("dg",.05),
				new DigramValue("di",.1),
				new DigramValue("dj",.05),
				new DigramValue("dl",.1),
				new DigramValue("do",.1),
				new DigramValue("dr",.1),
				new DigramValue("dq",.05),
				new DigramValue("dt",.1),
				new DigramValue("dv",.05)
			}
		},
		{
			"re", 
			new List<DigramValue>() {
				new DigramValue("ea",.05),
				new DigramValue("eb",.025),
				new DigramValue("ec",.05),
				new DigramValue("ed",.05),
				new DigramValue("ef",.025),
				new DigramValue("eg",.05),
				new DigramValue("eh",.025),
				new DigramValue("ei",.05),
				new DigramValue("ek",.025),
				new DigramValue("ee",.05),
				new DigramValue("el",.05),
				new DigramValue("ej",.025),
				new DigramValue("em",.05),
				new DigramValue("en",.05),
				new DigramValue("ep",.025),
				new DigramValue("eq",.025),
				new DigramValue("er",.05),
				new DigramValue("es",.05),
				new DigramValue("et",.05),
				new DigramValue("ev",.05),
				new DigramValue("ew",.05),
				new DigramValue("ex",.05),
				new DigramValue("ey",.025)
			}
		},
		{
			"rg", 
			new List<DigramValue>() {
				new DigramValue("ga",.1),
				new DigramValue("ge",.1),
				new DigramValue("gg",.1),
				new DigramValue("gh",.1),
				new DigramValue("gi",.1),
				new DigramValue("gl",.1),
				new DigramValue("gn",.05),
				new DigramValue("go",.1),
				new DigramValue("gr",.1),
				new DigramValue("gu",.1),
				new DigramValue("gy",.05)
			}
		},
		{
			"ri", 
			new List<DigramValue>() {
				new DigramValue("ic",.05),
				new DigramValue("id",.1),
				new DigramValue("if",.05),
				new DigramValue("ig",.05),
				new DigramValue("ik",.05),
				new DigramValue("il",.05),
				new DigramValue("im",.05),
				new DigramValue("in",.1),
				new DigramValue("io",.05),
				new DigramValue("ip",.05),
				new DigramValue("ir",.05),
				new DigramValue("is",.1),
				new DigramValue("it",.1),
				new DigramValue("iv",.05),
				new DigramValue("ix",.05),
				new DigramValue("iz",.05)
			}
		},
		{
			"rk", 
			new List<DigramValue>() {
				new DigramValue("ka",.1),
				new DigramValue("ke",.1),
				new DigramValue("ki",.2),
				new DigramValue("kl",.1),
				new DigramValue("kn",.1),
				new DigramValue("ko",.1),
				new DigramValue("kr",.1),
				new DigramValue("ku",.1),
				new DigramValue("kv",.1)
			}
		},
		{
			"rl", 
			new List<DigramValue>() {
				new DigramValue("la",.2),
				new DigramValue("le",.2),
				new DigramValue("li",.1),
				new DigramValue("ll",.1),
				new DigramValue("lk",.1),
				new DigramValue("lm",.1),
				new DigramValue("lo",.1),
				new DigramValue("lu",.1)
			}
		},
		{
			"rm", 
			new List<DigramValue>() {
				new DigramValue("ma",.1),
				new DigramValue("me",.2),
				new DigramValue("mi",.1),
				new DigramValue("mo",.2),
				new DigramValue("mp",.1),
				new DigramValue("mr",.1),
				new DigramValue("mu",.1),
				new DigramValue("mz",.1)
			}
		},
		{
			"rn", 
			new List<DigramValue>() {
				new DigramValue("na",.1),
				new DigramValue("ne",.1),
				new DigramValue("ni",.1),
				new DigramValue("nj",.05),
				new DigramValue("no",.1),
				new DigramValue("ns",.1),
				new DigramValue("nt",.1),
				new DigramValue("nu",.1)
			}
		},
		{
			"ro", 
			new List<DigramValue>() {
				new DigramValue("ob",.05),
				new DigramValue("oc",.05),
				new DigramValue("od",.1),
				new DigramValue("of",.05),
				new DigramValue("og",.05),
				new DigramValue("ok",.05),
				new DigramValue("ol",.05),
				new DigramValue("on",.1),
				new DigramValue("oo",.05),
				new DigramValue("op",.05),
				new DigramValue("or",.1),
				new DigramValue("os",.1),
				new DigramValue("ot",.05),
				new DigramValue("ov",.05),
				new DigramValue("ow",.05),
				new DigramValue("oy",.05)
			}
		},
		{
			"rp", 
			new List<DigramValue>() {
				new DigramValue("pa",.1),
				new DigramValue("pe",.1),
				new DigramValue("ph",.1),
				new DigramValue("po",.1),
				new DigramValue("pu",.1),
				new DigramValue("py",.2)
			}
		},
		{
			"rr", 
			new List<DigramValue>() {
				new DigramValue("ra",.1),
				new DigramValue("re",.05),
				new DigramValue("ri",.05),
				new DigramValue("ro",.05),
				new DigramValue("ru",.05),
			}
		},
		{
			"rs", 
			new List<DigramValue>() {
				new DigramValue("sa",.05),
				new DigramValue("se",.05),
				new DigramValue("so",.05),
				new DigramValue("su",.05),
				new DigramValue("sy",.05)
			}
		},
		{
			"rt", 
			new List<DigramValue>() {
				new DigramValue("ta",.1),
				new DigramValue("tc",.05),
				new DigramValue("te",.1),
				new DigramValue("th",.1),
				new DigramValue("ti",.1),
				new DigramValue("tl",.05),
				new DigramValue("to",.1),
				new DigramValue("tr",.1),
				new DigramValue("ts",.05),
				new DigramValue("tt",.1),
				new DigramValue("tu",.1),
				new DigramValue("ty",.05)
			}
		},
		{
			"ru", 
			new List<DigramValue>() {
				new DigramValue("ub",.1),
				new DigramValue("uc",.05),
				new DigramValue("ud",.1),
				new DigramValue("ug",.05),
				new DigramValue("ul",.1),
				new DigramValue("um",.1),
				new DigramValue("un",.1),
				new DigramValue("up",.1),
				new DigramValue("ur",.1),
				new DigramValue("us",.1),
				new DigramValue("ut",.1)
			}
		},
		{
			"rv", 
			new List<DigramValue>() {
				new DigramValue("va",.1),
				new DigramValue("ve",.1),
				new DigramValue("vi",.1),
				new DigramValue("vo",.1),
			}
		},
		{
			"rw", 
			new List<DigramValue>() {
				new DigramValue("wa",.2),
				new DigramValue("we",.2),
				new DigramValue("wh",.1),
				new DigramValue("wi",.1),
				new DigramValue("wo",.1),
				new DigramValue("wr",.2),
				new DigramValue("wu",.1)
			}
		},
		{
			"rx", 
			new List<DigramValue>() {
				new DigramValue("xa",.2),
				new DigramValue("xc",.2),
				new DigramValue("xi",.1),
				new DigramValue("xo",.1),
				new DigramValue("xp",.1),
				new DigramValue("xs",.1),
				new DigramValue("xt",.1),
				new DigramValue("xu",.1)
			}
		},

		{
			"sa", 
			new List<DigramValue>() {
				new DigramValue("ab",.05),
				new DigramValue("ac",.05),
				new DigramValue("ad",.05),
				new DigramValue("ae",.05),
				new DigramValue("af",.05),
				new DigramValue("ag",.05),
				new DigramValue("ah",.05),
				new DigramValue("ai",.05),
				new DigramValue("ak",.05),
				new DigramValue("al",.05),
				new DigramValue("am",.05),
				new DigramValue("an",.05),
				new DigramValue("ap",.05),
				new DigramValue("ar",.05),
				new DigramValue("as",.05),
				new DigramValue("at",.05),
				new DigramValue("au",.05),
				new DigramValue("av",.05),
				new DigramValue("aw",.025),
				new DigramValue("ax",.025),
				new DigramValue("ay",.025),
				new DigramValue("az",.025)
			}
		},
		{
			"sc", 
			new List<DigramValue>() {
				new DigramValue("ca",.1),
				new DigramValue("cb",.05),
				new DigramValue("ce",.1),
				new DigramValue("ch",.1),
				new DigramValue("ci",.05),
				new DigramValue("cl",.1),
				new DigramValue("ck",.1),
				new DigramValue("co",.1),
				new DigramValue("cr",.1),
				new DigramValue("cu",.05),
				new DigramValue("cw",.05),
				new DigramValue("cy",.05)
			}
		},
		{
			"se", 
			new List<DigramValue>() {
				new DigramValue("ea",.05),
				new DigramValue("eb",.025),
				new DigramValue("ec",.05),
				new DigramValue("ed",.05),
				new DigramValue("ef",.025),
				new DigramValue("eg",.05),
				new DigramValue("eh",.025),
				new DigramValue("ei",.05),
				new DigramValue("ek",.025),
				new DigramValue("ee",.05),
				new DigramValue("el",.05),
				new DigramValue("ej",.025),
				new DigramValue("em",.05),
				new DigramValue("en",.05),
				new DigramValue("ep",.025),
				new DigramValue("eq",.025),
				new DigramValue("er",.05),
				new DigramValue("es",.05),
				new DigramValue("et",.05),
				new DigramValue("ev",.05),
				new DigramValue("ew",.05),
				new DigramValue("ex",.05),
				new DigramValue("ey",.025)
			}
		},
		{
			"sh", 
			new List<DigramValue>() {
				new DigramValue("ha",.2),
				new DigramValue("he",.1),
				new DigramValue("hi",.1),
				new DigramValue("ho",.2),
				new DigramValue("hu",.1)
			}
		},
		{
			"si", 
			new List<DigramValue>() {
				new DigramValue("ic",.05),
				new DigramValue("id",.1),
				new DigramValue("if",.05),
				new DigramValue("ig",.05),
				new DigramValue("ik",.05),
				new DigramValue("il",.05),
				new DigramValue("im",.05),
				new DigramValue("in",.1),
				new DigramValue("io",.05),
				new DigramValue("ip",.05),
				new DigramValue("ir",.05),
				new DigramValue("is",.1),
				new DigramValue("it",.1),
				new DigramValue("iv",.05),
				new DigramValue("ix",.05),
				new DigramValue("iz",.05)
			}
		},
		{
			"sj", 
			new List<DigramValue>() {
				new DigramValue("ja",.2),
				new DigramValue("je",.2),
				new DigramValue("ji",.2),
				new DigramValue("jo",.2),
				new DigramValue("ju",.2)
			}
		},
		{
			"sk", 
			new List<DigramValue>() {
				new DigramValue("ka",.1),
				new DigramValue("ke",.1),
				new DigramValue("ki",.2),
				new DigramValue("kl",.1),
				new DigramValue("kn",.1),
				new DigramValue("ko",.1),
				new DigramValue("kr",.1),
				new DigramValue("ku",.1),
				new DigramValue("kv",.1)
			}
		},
		{
			"sl", 
			new List<DigramValue>() {
				new DigramValue("la",.2),
				new DigramValue("le",.2),
				new DigramValue("li",.1),
				new DigramValue("lo",.1),
				new DigramValue("lu",.1)
			}
		},
		{
			"sm", 
			new List<DigramValue>() {
				new DigramValue("ma",.1),
				new DigramValue("me",.2),
				new DigramValue("mi",.1),
				new DigramValue("mo",.2),
				new DigramValue("mu",.1)
			}
		},
		{
			"sn", 
			new List<DigramValue>() {
				new DigramValue("na",.1),
				new DigramValue("ne",.1),
				new DigramValue("ni",.1),
				new DigramValue("no",.1),
				new DigramValue("nu",.1)
			}
		},
		{
			"so", 
			new List<DigramValue>() {
				new DigramValue("ob",.05),
				new DigramValue("oc",.05),
				new DigramValue("od",.1),
				new DigramValue("of",.05),
				new DigramValue("og",.05),
				new DigramValue("ok",.05),
				new DigramValue("ol",.05),
				new DigramValue("on",.1),
				new DigramValue("oo",.05),
				new DigramValue("op",.05),
				new DigramValue("or",.1),
				new DigramValue("os",.1),
				new DigramValue("ot",.05),
				new DigramValue("ov",.05),
				new DigramValue("ow",.05),
				new DigramValue("oy",.05)
			}
		},
		{
			"sp", 
			new List<DigramValue>() {
				new DigramValue("pa",.1),
				new DigramValue("pe",.1),
				new DigramValue("ph",.1),
				new DigramValue("pl",.1),
				new DigramValue("po",.1),
				new DigramValue("pr",.1),
				new DigramValue("pu",.1),
				new DigramValue("py",.2)
			}
		},
		{
			"sq", 
			new List<DigramValue>() {
				new DigramValue("qa",.5),
				new DigramValue("qu",.5)
			}

		},			
		{
			"sr", 
			new List<DigramValue>() {
				new DigramValue("ra",.1),
				new DigramValue("ri",.05),
				new DigramValue("ro",.05)
			}
		},
		{
			"ss", 
			new List<DigramValue>() {
				new DigramValue("sa",.05),
				new DigramValue("se",.05),
				new DigramValue("si",.05),
				new DigramValue("so",.05),
				new DigramValue("su",.05)
			}
		},
		{
			"st", 
			new List<DigramValue>() {
				new DigramValue("ta",.1),
				new DigramValue("te",.1),
				new DigramValue("ti",.1),
				new DigramValue("to",.1),
				new DigramValue("tr",.1),
				new DigramValue("tu",.1),
				new DigramValue("ty",.05)
			}
		},
		{
			"su", 
			new List<DigramValue>() {
				new DigramValue("ub",.1),
				new DigramValue("uc",.05),
				new DigramValue("ud",.1),
				new DigramValue("ug",.05),
				new DigramValue("ul",.1),
				new DigramValue("um",.1),
				new DigramValue("un",.1),
				new DigramValue("up",.1),
				new DigramValue("ur",.1),
				new DigramValue("us",.1),
				new DigramValue("ut",.1)
			}
		},
		{
			"sv", 
			new List<DigramValue>() {
				new DigramValue("va",.1),
				new DigramValue("ve",.1),
				new DigramValue("vi",.1),
				new DigramValue("vo",.1),
				new DigramValue("vy",.1)
			}
		},
		{
			"sy", 
			new List<DigramValue>() {
				new DigramValue("ya",.1),
				new DigramValue("yc",.1),
				new DigramValue("ye",.1),
				new DigramValue("yi",.1),
				new DigramValue("yo",.1),
				new DigramValue("yr",.1),
				new DigramValue("yt",.1),
				new DigramValue("yu",.1),
				new DigramValue("yy",.1)
			}
		},

		{
			"ta", 
			new List<DigramValue>() {
				new DigramValue("ab",.05),
				new DigramValue("ac",.05),
				new DigramValue("ad",.05),
				new DigramValue("ae",.05),
				new DigramValue("af",.05),
				new DigramValue("ag",.05),
				new DigramValue("ah",.05),
				new DigramValue("ai",.05),
				new DigramValue("ak",.05),
				new DigramValue("al",.05),
				new DigramValue("am",.05),
				new DigramValue("an",.05),
				new DigramValue("ap",.05),
				new DigramValue("ar",.05),
				new DigramValue("as",.05),
				new DigramValue("at",.05),
				new DigramValue("au",.05),
				new DigramValue("av",.05),
				new DigramValue("aw",.025),
				new DigramValue("ax",.025),
				new DigramValue("ay",.025),
				new DigramValue("az",.025)
			}
		},
		{
			"tc", 
			new List<DigramValue>() {
				new DigramValue("ca",.1),
				new DigramValue("co",.1),
				new DigramValue("cu",.05)
			}
		},
		{
			"te", 
			new List<DigramValue>() {
				new DigramValue("ea",.05),
				new DigramValue("eb",.025),
				new DigramValue("ec",.05),
				new DigramValue("ed",.05),
				new DigramValue("ef",.025),
				new DigramValue("eg",.05),
				new DigramValue("eh",.025),
				new DigramValue("ei",.05),
				new DigramValue("ek",.025),
				new DigramValue("ee",.05),
				new DigramValue("el",.05),
				new DigramValue("ej",.025),
				new DigramValue("em",.05),
				new DigramValue("en",.05),
				new DigramValue("ep",.025),
				new DigramValue("eq",.025),
				new DigramValue("er",.05),
				new DigramValue("es",.05),
				new DigramValue("et",.05),
				new DigramValue("ev",.05),
				new DigramValue("ew",.05),
				new DigramValue("ex",.05),
				new DigramValue("ey",.025)
			}
		},
		{
			"th", 
			new List<DigramValue>() {
				new DigramValue("ha",.2),
				new DigramValue("he",.1),
				new DigramValue("hi",.1),
				new DigramValue("ho",.2),
				new DigramValue("hr",.1),
				new DigramValue("hu",.1)
			}
		},
		{
			"ti", 
			new List<DigramValue>() {
				new DigramValue("ic",.05),
				new DigramValue("id",.1),
				new DigramValue("if",.05),
				new DigramValue("ig",.05),
				new DigramValue("ik",.05),
				new DigramValue("il",.05),
				new DigramValue("im",.05),
				new DigramValue("in",.1),
				new DigramValue("io",.05),
				new DigramValue("ip",.05),
				new DigramValue("ir",.05),
				new DigramValue("is",.1),
				new DigramValue("it",.1),
				new DigramValue("iv",.05),
				new DigramValue("ix",.05),
				new DigramValue("iz",.05)
			}
		},
		{
			"tl", 
			new List<DigramValue>() {
				new DigramValue("la",.2),
				new DigramValue("le",.2),
				new DigramValue("li",.1)
			}
		},
		{
			"to", 
			new List<DigramValue>() {
				new DigramValue("ob",.05),
				new DigramValue("oc",.05),
				new DigramValue("od",.1),
				new DigramValue("of",.05),
				new DigramValue("og",.05),
				new DigramValue("ok",.05),
				new DigramValue("ol",.05),
				new DigramValue("on",.1),
				new DigramValue("oo",.05),
				new DigramValue("op",.05),
				new DigramValue("or",.1),
				new DigramValue("os",.1),
				new DigramValue("ot",.05),
				new DigramValue("ov",.05),
				new DigramValue("ow",.05),
				new DigramValue("oy",.05)
			}
		},
		{
			"tr", 
			new List<DigramValue>() {
				new DigramValue("ra",.1),
				new DigramValue("re",.05),
				new DigramValue("ri",.05),
				new DigramValue("ro",.05),
				new DigramValue("ru",.05)
			}
		},
		{
			"ts", 
			new List<DigramValue>() {
				new DigramValue("sa",.05),
				new DigramValue("se",.05),
				new DigramValue("si",.05),
				new DigramValue("so",.05),
				new DigramValue("su",.05)
			}
		},
		{
			"tt", 
			new List<DigramValue>() {
				new DigramValue("ta",.1),
				new DigramValue("te",.1),
				new DigramValue("ti",.1),
				new DigramValue("to",.1),
				new DigramValue("tu",.1),
				new DigramValue("ty",.05)
			}
		},
		{
			"tu", 
			new List<DigramValue>() {
				new DigramValue("ub",.1),
				new DigramValue("uc",.05),
				new DigramValue("ud",.1),
				new DigramValue("ug",.05),
				new DigramValue("ul",.1),
				new DigramValue("um",.1),
				new DigramValue("un",.1),
				new DigramValue("up",.1),
				new DigramValue("ur",.1),
				new DigramValue("us",.1),
				new DigramValue("ut",.1)
			}
		},
		{
			"ty", 
			new List<DigramValue>() {
				new DigramValue("ya",.1),
				new DigramValue("ye",.1),
				new DigramValue("yr",.1),
				new DigramValue("yy",.1)
			}
		},

		{
			"ub", 
			new List<DigramValue>() {
				new DigramValue("ba",.1),
				new DigramValue("be",.1),
				new DigramValue("bf",.1),
				new DigramValue("bh",.1),
				new DigramValue("bi",.1),
				new DigramValue("bl",.1),
				new DigramValue("bo",.1),
				new DigramValue("br",.1),
				new DigramValue("bu",.1),
				new DigramValue("by",.1)
			}
		},
		{
			"uc", 
			new List<DigramValue>() {
				new DigramValue("ca",.1),
				new DigramValue("cb",.05),
				new DigramValue("cc",.05),
				new DigramValue("ce",.1),
				new DigramValue("ch",.1),
				new DigramValue("ci",.05),
				new DigramValue("cl",.1),
				new DigramValue("ck",.1),
				new DigramValue("co",.1),
				new DigramValue("cr",.1),
				new DigramValue("cu",.05),
				new DigramValue("cw",.05),
				new DigramValue("cy",.05)
			}
		},
		{
			"ud", 
			new List<DigramValue>() {
				new DigramValue("da",.1),
				new DigramValue("de",.1),
				new DigramValue("df",.05),
				new DigramValue("dg",.05),
				new DigramValue("di",.1),
				new DigramValue("dj",.05),
				new DigramValue("dl",.1),
				new DigramValue("do",.1),
				new DigramValue("dr",.1),
				new DigramValue("dq",.05),
				new DigramValue("dt",.1),
				new DigramValue("dv",.05)
			}
		},
		{
			"ug", 
			new List<DigramValue>() {
				new DigramValue("ga",.1),
				new DigramValue("ge",.1),
				new DigramValue("gg",.1),
				new DigramValue("gh",.1),
				new DigramValue("gi",.1),
				new DigramValue("gl",.1),
				new DigramValue("gn",.05),
				new DigramValue("go",.1),
				new DigramValue("gr",.1),
				new DigramValue("gu",.1),
				new DigramValue("gy",.05)
			}
		},
		{
			"ul", 
			new List<DigramValue>() {
				new DigramValue("la",.2),
				new DigramValue("le",.2),
				new DigramValue("li",.1),
				new DigramValue("ll",.1),
				new DigramValue("lk",.1),
				new DigramValue("lm",.1),
				new DigramValue("lo",.1),
				new DigramValue("lu",.1)
			}
		},
		{
			"um", 
			new List<DigramValue>() {
				new DigramValue("ma",.1),
				new DigramValue("me",.2),
				new DigramValue("mi",.1),
				new DigramValue("mo",.2),
				new DigramValue("mp",.1),
				new DigramValue("mr",.1),
				new DigramValue("mu",.1),
				new DigramValue("mz",.1)
			}
		},
		{
			"un", 
			new List<DigramValue>() {
				new DigramValue("na",.1),
				new DigramValue("nc",.05),
				new DigramValue("nd",.05),
				new DigramValue("ne",.1),
				new DigramValue("ni",.1),
				new DigramValue("nj",.05),
				new DigramValue("nk",.1),
				new DigramValue("nn",.1),
				new DigramValue("no",.1),
				new DigramValue("ns",.1),
				new DigramValue("nt",.1),
				new DigramValue("nu",.1)
			}
		},
		{
			"up", 
			new List<DigramValue>() {
				new DigramValue("pa",.1),
				new DigramValue("pe",.1),
				new DigramValue("ph",.1),
				new DigramValue("pl",.1),
				new DigramValue("pn",.1),
				new DigramValue("po",.1),
				new DigramValue("pr",.1),
				new DigramValue("pu",.1),
				new DigramValue("py",.2)
			}
		},
		{
			"ur", 
			new List<DigramValue>() {
				new DigramValue("ra",.1),
				new DigramValue("rc",.05),
				new DigramValue("rd",.05),
				new DigramValue("re",.05),
				new DigramValue("rg",.05),
				new DigramValue("ri",.05),
				new DigramValue("rk",.05),
				new DigramValue("rl",.05),
				new DigramValue("rm",.05),
				new DigramValue("rn",.05),
				new DigramValue("ro",.05),
				new DigramValue("rp",.05),
				new DigramValue("rr",.05),
				new DigramValue("rs",.05),
				new DigramValue("rt",.05),
				new DigramValue("ru",.05),
				new DigramValue("rv",.05),
				new DigramValue("rw",.05),
				new DigramValue("rx",.05)
			}
		},
		{
			"us", 
			new List<DigramValue>() {
				new DigramValue("sa",.05),
				new DigramValue("sc",.1),
				new DigramValue("se",.05),
				new DigramValue("sh",.05),
				new DigramValue("si",.05),
				new DigramValue("sj",.05),
				new DigramValue("sk",.05),
				new DigramValue("sl",.05),
				new DigramValue("sm",.05),
				new DigramValue("sn",.05),
				new DigramValue("so",.05),
				new DigramValue("sp",.05),
				new DigramValue("sq",.05),
				new DigramValue("sr",.05),
				new DigramValue("ss",.05),
				new DigramValue("st",.05),
				new DigramValue("su",.05),
				new DigramValue("sv",.05),
				new DigramValue("sy",.05)
			}
		},
		{
			"ut", 
			new List<DigramValue>() {
				new DigramValue("ta",.1),
				new DigramValue("tc",.05),
				new DigramValue("te",.1),
				new DigramValue("th",.1),
				new DigramValue("ti",.1),
				new DigramValue("tl",.05),
				new DigramValue("to",.1),
				new DigramValue("tr",.1),
				new DigramValue("ts",.05),
				new DigramValue("tt",.1),
				new DigramValue("tu",.1),
				new DigramValue("ty",.05)
			}
		},

		{
			"va", 
			new List<DigramValue>() {
				new DigramValue("ab",.05),
				new DigramValue("ac",.05),
				new DigramValue("ad",.05),
				new DigramValue("ae",.05),
				new DigramValue("af",.05),
				new DigramValue("ag",.05),
				new DigramValue("ah",.05),
				new DigramValue("ai",.05),
				new DigramValue("ak",.05),
				new DigramValue("al",.05),
				new DigramValue("am",.05),
				new DigramValue("an",.05),
				new DigramValue("ap",.05),
				new DigramValue("ar",.05),
				new DigramValue("as",.05),
				new DigramValue("at",.05),
				new DigramValue("au",.05),
				new DigramValue("av",.05),
				new DigramValue("aw",.025),
				new DigramValue("ax",.025),
				new DigramValue("ay",.025),
				new DigramValue("az",.025)
			}
		},
		{
			"vb", 
			new List<DigramValue>() {
				new DigramValue("ba",.1),
				new DigramValue("be",.1),
				new DigramValue("bf",.1),
				new DigramValue("bh",.1),
				new DigramValue("bi",.1),
				new DigramValue("bl",.1),
				new DigramValue("bo",.1),
				new DigramValue("br",.1),
				new DigramValue("bu",.1),
				new DigramValue("by",.1)
			}
		},
		{
			"ve", 
			new List<DigramValue>() {
				new DigramValue("ea",.05),
				new DigramValue("eb",.025),
				new DigramValue("ec",.05),
				new DigramValue("ed",.05),
				new DigramValue("ef",.025),
				new DigramValue("eg",.05),
				new DigramValue("eh",.025),
				new DigramValue("ei",.05),
				new DigramValue("ek",.025),
				new DigramValue("ee",.05),
				new DigramValue("el",.05),
				new DigramValue("ej",.025),
				new DigramValue("em",.05),
				new DigramValue("en",.05),
				new DigramValue("ep",.025),
				new DigramValue("eq",.025),
				new DigramValue("er",.05),
				new DigramValue("es",.05),
				new DigramValue("et",.05),
				new DigramValue("ev",.05),
				new DigramValue("ew",.05),
				new DigramValue("ex",.05),
				new DigramValue("ey",.025)
			}
		},
		{
			"vh", 
			new List<DigramValue>() {
				new DigramValue("ha",.2),
				new DigramValue("he",.1),
				new DigramValue("hi",.1),
				new DigramValue("ho",.2),
				new DigramValue("hu",.1)
			}
		},
		{
			"vi", 
			new List<DigramValue>() {
				new DigramValue("ic",.05),
				new DigramValue("id",.1),
				new DigramValue("if",.05),
				new DigramValue("ig",.05),
				new DigramValue("ik",.05),
				new DigramValue("il",.05),
				new DigramValue("im",.05),
				new DigramValue("in",.1),
				new DigramValue("io",.05),
				new DigramValue("ip",.05),
				new DigramValue("ir",.05),
				new DigramValue("is",.1),
				new DigramValue("it",.1),
				new DigramValue("iv",.05),
				new DigramValue("ix",.05),
				new DigramValue("iz",.05)
			}
		},
		{
			"vj", 
			new List<DigramValue>() {
				new DigramValue("ja",.2),
				new DigramValue("je",.2),
				new DigramValue("ji",.2),
				new DigramValue("jo",.2),
				new DigramValue("ju",.2)
			}
		},
		{
			"vl", 
			new List<DigramValue>() {
				new DigramValue("la",.2),
				new DigramValue("le",.2),
				new DigramValue("li",.1),
				new DigramValue("ll",.1),
				new DigramValue("lo",.1),
				new DigramValue("lu",.1)
			}
		},
		{
			"vo", 
			new List<DigramValue>() {
				new DigramValue("ob",.05),
				new DigramValue("oc",.05),
				new DigramValue("od",.1),
				new DigramValue("of",.05),
				new DigramValue("og",.05),
				new DigramValue("ok",.05),
				new DigramValue("ol",.05),
				new DigramValue("on",.1),
				new DigramValue("oo",.05),
				new DigramValue("op",.05),
				new DigramValue("or",.1),
				new DigramValue("os",.1),
				new DigramValue("ot",.05),
				new DigramValue("ov",.05),
				new DigramValue("ow",.05),
				new DigramValue("oy",.05)
			}
		},
		{
			"vr", 
			new List<DigramValue>() {
				new DigramValue("ra",.1),
				new DigramValue("re",.05),
				new DigramValue("ri",.05),
				new DigramValue("ro",.05),
				new DigramValue("ru",.05)
			}
		},
		{
			"vu", 
			new List<DigramValue>() {
				new DigramValue("ub",.1),
				new DigramValue("uc",.05),
				new DigramValue("ud",.1),
				new DigramValue("ug",.05),
				new DigramValue("ul",.1),
				new DigramValue("um",.1),
				new DigramValue("un",.1),
				new DigramValue("up",.1),
				new DigramValue("ur",.1),
				new DigramValue("us",.1),
				new DigramValue("ut",.1)
			}
		},
		{
			"vy", 
			new List<DigramValue>() {
				new DigramValue("ya",.1),
				new DigramValue("yc",.1),
				new DigramValue("ye",.1),
				new DigramValue("yi",.1),
				new DigramValue("yo",.1),
				new DigramValue("yr",.1),
				new DigramValue("yt",.1),
				new DigramValue("yu",.1),
				new DigramValue("yy",.1)
			}
		},

		{
			"wa", 
			new List<DigramValue>() {
				new DigramValue("ab",.05),
				new DigramValue("ac",.05),
				new DigramValue("ad",.05),
				new DigramValue("ae",.05),
				new DigramValue("af",.05),
				new DigramValue("ag",.05),
				new DigramValue("ah",.05),
				new DigramValue("ai",.05),
				new DigramValue("ak",.05),
				new DigramValue("al",.05),
				new DigramValue("am",.05),
				new DigramValue("an",.05),
				new DigramValue("ap",.05),
				new DigramValue("ar",.05),
				new DigramValue("as",.05),
				new DigramValue("at",.05),
				new DigramValue("au",.05),
				new DigramValue("av",.05),
				new DigramValue("aw",.025),
				new DigramValue("ax",.025),
				new DigramValue("ay",.025),
				new DigramValue("az",.025)
			}
		},
		{
			"we", 
			new List<DigramValue>() {
				new DigramValue("ea",.05),
				new DigramValue("eb",.025),
				new DigramValue("ec",.05),
				new DigramValue("ed",.05),
				new DigramValue("ef",.025),
				new DigramValue("eg",.05),
				new DigramValue("eh",.025),
				new DigramValue("ei",.05),
				new DigramValue("ek",.025),
				new DigramValue("ee",.05),
				new DigramValue("el",.05),
				new DigramValue("ej",.025),
				new DigramValue("em",.05),
				new DigramValue("en",.05),
				new DigramValue("ep",.025),
				new DigramValue("eq",.025),
				new DigramValue("er",.05),
				new DigramValue("es",.05),
				new DigramValue("et",.05),
				new DigramValue("ev",.05),
				new DigramValue("ew",.05),
				new DigramValue("ex",.05),
				new DigramValue("ey",.025)
			}
		},
		{
			"wh", 
			new List<DigramValue>() {
				new DigramValue("ha",.2),
				new DigramValue("he",.1),
				new DigramValue("hi",.1),
				new DigramValue("ho",.2),
				new DigramValue("hu",.1)
			}
		},
		{
			"wi", 
			new List<DigramValue>() {
				new DigramValue("ic",.05),
				new DigramValue("id",.1),
				new DigramValue("if",.05),
				new DigramValue("ig",.05),
				new DigramValue("ik",.05),
				new DigramValue("il",.05),
				new DigramValue("im",.05),
				new DigramValue("in",.1),
				new DigramValue("io",.05),
				new DigramValue("ip",.05),
				new DigramValue("ir",.05),
				new DigramValue("is",.1),
				new DigramValue("it",.1),
				new DigramValue("iv",.05),
				new DigramValue("ix",.05),
				new DigramValue("iz",.05)
			}
		},
		{
			"wo", 
			new List<DigramValue>() {
				new DigramValue("ob",.05),
				new DigramValue("oc",.05),
				new DigramValue("od",.1),
				new DigramValue("of",.05),
				new DigramValue("og",.05),
				new DigramValue("ok",.05),
				new DigramValue("ol",.05),
				new DigramValue("on",.1),
				new DigramValue("oo",.05),
				new DigramValue("op",.05),
				new DigramValue("or",.1),
				new DigramValue("os",.1),
				new DigramValue("ot",.05),
				new DigramValue("ov",.05),
				new DigramValue("ow",.05),
				new DigramValue("oy",.05)
			}
		},
		{
			"wr", 
			new List<DigramValue>() {
				new DigramValue("ra",.1),
				new DigramValue("re",.05),
				new DigramValue("ri",.05),
				new DigramValue("ro",.05),
				new DigramValue("ru",.05)
			}
		},
		{
			"wu", 
			new List<DigramValue>() {
				new DigramValue("ub",.1),
				new DigramValue("uc",.05),
				new DigramValue("ud",.1),
				new DigramValue("ug",.05),
				new DigramValue("ul",.1),
				new DigramValue("um",.1),
				new DigramValue("un",.1),
				new DigramValue("up",.1),
				new DigramValue("ur",.1),
				new DigramValue("us",.1),
				new DigramValue("ut",.1)
			}
		},

		{
			"xa", 
			new List<DigramValue>() {
				new DigramValue("ab",.05),
				new DigramValue("ac",.05),
				new DigramValue("ad",.05),
				new DigramValue("ae",.05),
				new DigramValue("af",.05),
				new DigramValue("ag",.05),
				new DigramValue("ah",.05),
				new DigramValue("ai",.05),
				new DigramValue("ak",.05),
				new DigramValue("al",.05),
				new DigramValue("am",.05),
				new DigramValue("an",.05),
				new DigramValue("ap",.05),
				new DigramValue("ar",.05),
				new DigramValue("as",.05),
				new DigramValue("at",.05),
				new DigramValue("au",.05),
				new DigramValue("av",.05),
				new DigramValue("aw",.025),
				new DigramValue("ax",.025),
				new DigramValue("ay",.025),
				new DigramValue("az",.025)
			}
		},
		{
			"xc", 
			new List<DigramValue>() {
				new DigramValue("ca",.1),
				new DigramValue("cb",.05),
				new DigramValue("ce",.1),
				new DigramValue("ch",.1),
				new DigramValue("ci",.05),
				new DigramValue("cl",.1),
				new DigramValue("ck",.1),
				new DigramValue("co",.1),
				new DigramValue("cr",.1),
				new DigramValue("cu",.05),
				new DigramValue("cw",.05),
				new DigramValue("cy",.05)
			}
		},
		{
			"xi", 
			new List<DigramValue>() {
				new DigramValue("id",.1),
				new DigramValue("if",.05),
				new DigramValue("il",.05),
				new DigramValue("im",.05),
				new DigramValue("in",.1),
				new DigramValue("io",.05),
				new DigramValue("is",.1)
			}
		},
		{
			"xo", 
			new List<DigramValue>() {
				new DigramValue("ob",.05),
				new DigramValue("oc",.05),
				new DigramValue("od",.1),
				new DigramValue("of",.05),
				new DigramValue("og",.05),
				new DigramValue("ok",.05),
				new DigramValue("ol",.05),
				new DigramValue("on",.1),
				new DigramValue("oo",.05),
				new DigramValue("op",.05),
				new DigramValue("or",.1),
				new DigramValue("os",.1),
				new DigramValue("ot",.05),
				new DigramValue("ov",.05),
				new DigramValue("ow",.05),
				new DigramValue("oy",.05)
			}
		},
		{
			"xp", 
			new List<DigramValue>() {
				new DigramValue("pa",.1),
				new DigramValue("pe",.1),
				new DigramValue("ph",.1),
				new DigramValue("pl",.1),
				new DigramValue("pn",.1),
				new DigramValue("po",.1),
				new DigramValue("pr",.1),
				new DigramValue("pu",.1),
				new DigramValue("py",.2)
			}
		},
		{
			"xs", 
			new List<DigramValue>() {
				new DigramValue("sa",.05),
				new DigramValue("se",.05),
				new DigramValue("si",.05),
				new DigramValue("so",.05),
				new DigramValue("su",.05),
				new DigramValue("sy",.05)
			}
		},
		{
			"xt", 
			new List<DigramValue>() {
				new DigramValue("ta",.1),
				new DigramValue("te",.1),
				new DigramValue("ti",.1),
				new DigramValue("to",.1),
				new DigramValue("tr",.1),
				new DigramValue("ty",.05)
			}
		},
		{
			"xu", 
			new List<DigramValue>() {
				new DigramValue("ub",.1),
				new DigramValue("uc",.05),
				new DigramValue("ud",.1),
				new DigramValue("ug",.05),
				new DigramValue("ul",.1),
				new DigramValue("um",.1),
				new DigramValue("un",.1),
				new DigramValue("up",.1),
				new DigramValue("ur",.1),
				new DigramValue("us",.1),
				new DigramValue("ut",.1)
			}
		},

		{
			"ya", 
			new List<DigramValue>() {
				new DigramValue("ab",.05),
				new DigramValue("ac",.05),
				new DigramValue("ad",.05),
				new DigramValue("ae",.05),
				new DigramValue("af",.05),
				new DigramValue("ag",.05),
				new DigramValue("ah",.05),
				new DigramValue("ai",.05),
				new DigramValue("ak",.05),
				new DigramValue("al",.05),
				new DigramValue("am",.05),
				new DigramValue("an",.05),
				new DigramValue("ap",.05),
				new DigramValue("ar",.05),
				new DigramValue("as",.05),
				new DigramValue("at",.05),
				new DigramValue("au",.05),
				new DigramValue("av",.05),
				new DigramValue("aw",.025),
				new DigramValue("ax",.025),
				new DigramValue("ay",.025),
				new DigramValue("az",.025)
			}
		},
		{
			"yc", 
			new List<DigramValue>() {
				new DigramValue("ca",.1),
				new DigramValue("ce",.1),
				new DigramValue("ch",.1),
				new DigramValue("co",.1),
				new DigramValue("cr",.1)
			}
		},
		{
			"ye", 
			new List<DigramValue>() {
				new DigramValue("ea",.05),
				new DigramValue("eb",.025),
				new DigramValue("ec",.05),
				new DigramValue("ed",.05),
				new DigramValue("ef",.025),
				new DigramValue("eg",.05),
				new DigramValue("eh",.025),
				new DigramValue("ei",.05),
				new DigramValue("ek",.025),
				new DigramValue("ee",.05),
				new DigramValue("el",.05),
				new DigramValue("ej",.025),
				new DigramValue("em",.05),
				new DigramValue("en",.05),
				new DigramValue("ep",.025),
				new DigramValue("eq",.025),
				new DigramValue("er",.05),
				new DigramValue("es",.05),
				new DigramValue("et",.05),
				new DigramValue("ev",.05),
				new DigramValue("ew",.05),
				new DigramValue("ex",.05),
				new DigramValue("ey",.025)
			}
		},
		{
			"yi", 
			new List<DigramValue>() {
				new DigramValue("ic",.05),
				new DigramValue("id",.1),
				new DigramValue("if",.05),
				new DigramValue("ig",.05),
				new DigramValue("ik",.05),
				new DigramValue("il",.05),
				new DigramValue("im",.05),
				new DigramValue("in",.1),
				new DigramValue("io",.05),
				new DigramValue("ip",.05),
				new DigramValue("ir",.05),
				new DigramValue("is",.1),
				new DigramValue("it",.1),
				new DigramValue("iv",.05),
				new DigramValue("ix",.05),
				new DigramValue("iz",.05)
			}
		},
		{
			"yj", 
			new List<DigramValue>() {
				new DigramValue("ja",.2),
				new DigramValue("je",.2),
				new DigramValue("ji",.2),
				new DigramValue("jo",.2),
				new DigramValue("ju",.2)
			}
		},
		{
			"yo", 
			new List<DigramValue>() {
				new DigramValue("ob",.05),
				new DigramValue("oc",.05),
				new DigramValue("od",.1),
				new DigramValue("of",.05),
				new DigramValue("og",.05),
				new DigramValue("ok",.05),
				new DigramValue("ol",.05),
				new DigramValue("on",.1),
				new DigramValue("oo",.05),
				new DigramValue("op",.05),
				new DigramValue("or",.1),
				new DigramValue("os",.1),
				new DigramValue("ot",.05),
				new DigramValue("ov",.05),
				new DigramValue("ow",.05),
				new DigramValue("oy",.05)
			}
		},
		{
			"yr", 
			new List<DigramValue>() {
				new DigramValue("ra",.1),
				new DigramValue("re",.05),
				new DigramValue("ri",.05),
				new DigramValue("ro",.05),
				new DigramValue("ru",.05)
			}
		},
		{
			"yt", 
			new List<DigramValue>() {
				new DigramValue("ta",.1),
				new DigramValue("te",.1),
				new DigramValue("th",.1),
				new DigramValue("to",.1),
				new DigramValue("tr",.1)
			}
		},
		{
			"yu", 
			new List<DigramValue>() {
				new DigramValue("ub",.1),
				new DigramValue("uc",.05),
				new DigramValue("ud",.1),
				new DigramValue("ug",.05),
				new DigramValue("ul",.1),
				new DigramValue("um",.1),
				new DigramValue("un",.1),
				new DigramValue("up",.1),
				new DigramValue("ur",.1),
				new DigramValue("us",.1),
				new DigramValue("ut",.1)
			}
		},
		{
			"yy", 
			new List<DigramValue>() {
				new DigramValue("ya",.1),
				new DigramValue("yc",.1),
				new DigramValue("ye",.1),
				new DigramValue("yi",.1),
				new DigramValue("yj",.1),
				new DigramValue("yo",.1),
				new DigramValue("yr",.1),
				new DigramValue("yt",.1),
				new DigramValue("yu",.1),
				new DigramValue("yy",.1)
			}
		},

		{
			"za", 
			new List<DigramValue>() {
				new DigramValue("ab",.05),
				new DigramValue("ac",.05),
				new DigramValue("ad",.05),
				new DigramValue("ae",.05),
				new DigramValue("af",.05),
				new DigramValue("ag",.05),
				new DigramValue("ah",.05),
				new DigramValue("ai",.05),
				new DigramValue("ak",.05),
				new DigramValue("al",.05),
				new DigramValue("am",.05),
				new DigramValue("an",.05),
				new DigramValue("ap",.05),
				new DigramValue("ar",.05),
				new DigramValue("as",.05),
				new DigramValue("at",.05),
				new DigramValue("au",.05),
				new DigramValue("av",.05),
				new DigramValue("aw",.025),
				new DigramValue("ax",.025),
				new DigramValue("ay",.025),
				new DigramValue("az",.025)
			}
		},
		{
			"ze", 
			new List<DigramValue>() {
				new DigramValue("ea",.05),
				new DigramValue("eb",.025),
				new DigramValue("ec",.05),
				new DigramValue("ed",.05),
				new DigramValue("ef",.025),
				new DigramValue("eg",.05),
				new DigramValue("eh",.025),
				new DigramValue("ei",.05),
				new DigramValue("ek",.025),
				new DigramValue("ee",.05),
				new DigramValue("el",.05),
				new DigramValue("ej",.025),
				new DigramValue("em",.05),
				new DigramValue("en",.05),
				new DigramValue("ep",.025),
				new DigramValue("eq",.025),
				new DigramValue("er",.05),
				new DigramValue("es",.05),
				new DigramValue("et",.05),
				new DigramValue("ev",.05),
				new DigramValue("ew",.05),
				new DigramValue("ex",.05),
				new DigramValue("ey",.025)
			}
		},
		{
			"zh", 
			new List<DigramValue>() {
				new DigramValue("ha",.2),
				new DigramValue("he",.1),
				new DigramValue("hi",.1),
				new DigramValue("ho",.2),
				new DigramValue("hu",.1)
			}
		},
		{
			"zi", 
			new List<DigramValue>() {
				new DigramValue("ic",.05),
				new DigramValue("id",.1),
				new DigramValue("if",.05),
				new DigramValue("ig",.05),
				new DigramValue("ik",.05),
				new DigramValue("il",.05),
				new DigramValue("im",.05),
				new DigramValue("in",.1),
				new DigramValue("io",.05),
				new DigramValue("ip",.05),
				new DigramValue("ir",.05),
				new DigramValue("is",.1),
				new DigramValue("it",.1),
				new DigramValue("iv",.05),
				new DigramValue("ix",.05),
				new DigramValue("iz",.05)
			}
		},
		{
			"zk", 
			new List<DigramValue>() {
				new DigramValue("ka",.1),
				new DigramValue("ke",.1),
				new DigramValue("ki",.2),
				new DigramValue("kl",.1),
				new DigramValue("kn",.1),
				new DigramValue("ko",.1),
				new DigramValue("kr",.1),
				new DigramValue("ku",.1),
				new DigramValue("kv",.1)
			}
		},
		{
			"zo", 
			new List<DigramValue>() {
				new DigramValue("ob",.05),
				new DigramValue("oc",.05),
				new DigramValue("od",.1),
				new DigramValue("of",.05),
				new DigramValue("og",.05),
				new DigramValue("ok",.05),
				new DigramValue("ol",.05),
				new DigramValue("on",.1),
				new DigramValue("oo",.05),
				new DigramValue("op",.05),
				new DigramValue("or",.1),
				new DigramValue("os",.1),
				new DigramValue("ot",.05),
				new DigramValue("ov",.05),
				new DigramValue("ow",.05),
				new DigramValue("oy",.05)
			}
		},
		{
			"zr", 
			new List<DigramValue>() {
				new DigramValue("ra",.1),
				new DigramValue("re",.05),
				new DigramValue("ru",.05),
				new DigramValue("rv",.05),
				new DigramValue("rw",.05),
				new DigramValue("rx",.05)
			}
		},
		{
			"zs", 
			new List<DigramValue>() {
				new DigramValue("sa",.05),
				new DigramValue("so",.05)
			}
		},
		{
			"zu", 
			new List<DigramValue>() {
				new DigramValue("ub",.1),
				new DigramValue("uc",.05),
				new DigramValue("ud",.1),
				new DigramValue("ug",.05),
				new DigramValue("ul",.1),
				new DigramValue("um",.1),
				new DigramValue("un",.1),
				new DigramValue("ur",.1)
			}
		},
		{
			"zz", 
			new List<DigramValue>() {
				new DigramValue("za",.1),
				new DigramValue("ze",.1),
				new DigramValue("zi",.1),
				new DigramValue("zo",.1),
				new DigramValue("zu",.1)
			}
		}
	};

	public NameGenerator(int numberOfPlanets) {
		numberToGenerate = numberOfPlanets;
		
	}

	private Dictionary<string, List<DigramValue>> sortWordFreq(Dictionary<string, List<DigramValue>> wordFreq) {
		Dictionary<string, List<DigramValue>> newWordFreq = new Dictionary<string, List<DigramValue>>();
		foreach (KeyValuePair<string, List<DigramValue>> pair in wordFreq) {
			//Sort the values to their priority
			List<DigramValue> sorted = new List<DigramValue>();
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
			List<DigramValue> combinedNewWeightsWithDigrams = new List<DigramValue>();
			for(int i=0; i<sorted.Count; i++) {
				DigramValue currentDigram = sorted.ElementAt(i);
				double newWeighting = adjustedWeightings.ElementAt(i);
				DigramValue newDigram = new DigramValue(currentDigram.digram, newWeighting);
				combinedNewWeightsWithDigrams.Add(newDigram);
			}

			newWordFreq.Add(pair.Key, combinedNewWeightsWithDigrams);
		}
		return newWordFreq;
	}

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
				List<DigramValue> output;
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

	private string generateSeed() {
		List<string> keyList = new List<string>(digramWordFreq.Keys);
		string randomKey = keyList[random.Next(keyList.Count)];
		while (disallowedForStart.Contains(randomKey)) {
			randomKey = keyList[random.Next(keyList.Count)];
		}
		return randomKey;
	}

	private string getRandomDigram(List<DigramValue> listOfPossibleDigrams) {
		double probability = random.NextDouble();
		foreach (DigramValue digramVal in listOfPossibleDigrams) {
			probability -= digramVal.frequency;
			if (probability <= 0) {
				return digramVal.digram.Substring(1,1); 
			}
		}
		//Fetch the last element in the case of failure
		return listOfPossibleDigrams.ElementAt(listOfPossibleDigrams.Count-1).digram.Substring(1,1);
	}

	private string uppercaseFirst(string s) {
		if (string.IsNullOrEmpty(s))
		{
		    return string.Empty;
		}
		char[] a = s.ToCharArray();
		a[0] = char.ToUpper(a[0]);
		return new string(a);
	}

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

	public string generatePlanetName() {
		return generate("", 8);
	}

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
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;

public class WordSequences {

	/**
	 * Class that represents a pairing of digrams and their respective frequency
	 */
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

	public static Dictionary<string, List<DigramValue>> getSequences() {
		return new Dictionary<string, List<DigramValue>>() {
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
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GuessGame
{
    public static class SayiyaDonusturme
    {
        private static Dictionary<string, int> sayilar = new Dictionary<string, int>
        {
         {"sıfır",0},{"bir",1},{"iki",2},{"üç",3},{"dört",4},{"beş",5},{"altı",6},
    {"yedi",7},{"sekiz",8},{"dokuz",9},{"on",10},{"onbir",11},{"oniki",12},
    {"onüç",13},{"ondört",14},{"onbeş",15},{"onaltı",16},{"onyedi",17},
    {"onsekiz",18},{"ondokuz",19},{"yirmi",20},{"yirmibir",21},{"yirmiiki",22},
    {"yirmiüç",23},{"yirmidört",24},{"yirmibeş",25},{"yirmialtı",26},
    {"yirmiyedi",27},{"yirmisekiz",28},{"yirmidokuz",29},{"otuz",30},
    {"otuzbir",31},{"otuziki",32},{"otuzüç",33},{"otuzdört",34},{"otuzbeş",35},
    {"otuzaltı",36},{"otuzyedi",37},{"otuzsekiz",38},{"otuzdokuz",39},
    {"kırk",40},{"kırkbir",41},{"kırkiki",42},{"kırküç",43},{"kırkdört",44},
    {"kırkbeş",45},{"kırkaltı",46},{"kırkyedi",47},{"kırksekiz",48},
    {"kırkdokuz",49},{"elli",50},{"ellibir",51},{"elliiki",52},{"elliaç",53},
    {"ellidört",54},{"ellibeş",55},{"ellialtı",56},{"elliyedi",57},
    {"ellisekiz",58},{"ellidokuz",59},{"altmış",60},{"altmışbir",61},
    {"altmışiki",62},{"altmışüç",63},{"altmışdört",64},{"altmışbeş",65},
    {"altmışaltı",66},{"altmışyedi",67},{"altmışsekiz",68},{"altmışdokuz",69},
    {"yetmiş",70},{"yetmişbir",71},{"yetmişiki",72},{"yetmişüç",73},
    {"yetmişdört",74},{"yetmişbeş",75},{"yetmişaltı",76},{"yetmişyedi",77},
    {"yetmişsekiz",78},{"yetmişdokuz",79},{"seksen",80},{"seksenbir",81},
    {"sekseniki",82},{"seksenüç",83},{"seksendört",84},{"seksenbeş",85},
    {"seksenaltı",86},{"seksenyedi",87},{"seksensekiz",88},{"seksendokuz",89},
    {"doksan",90},{"doksanbir",91},{"doksaniki",92},{"doksanıç",93},
    {"doksandört",94},{"doksanbeş",95},{"doksanaltı",96},{"doksanyedi",97},
    {"doksansekiz",98},{"doksandokuz",99},{"yüz",100}
        };
        private static Dictionary<string, int> numberss = new Dictionary<string, int> {
        {"zero", 0},{"one", 1},{ "two", 2},{ "three", 3},{ "four", 4},{ "five", 5},{ "six", 6},
    { "seven", 7},
{ "eight", 8},
{ "nine", 9},
{ "ten", 10},
{ "eleven", 11},
{ "twelve", 12},
{ "thirteen", 13},
{ "fourteen", 14},
{ "fifteen", 15},
{ "sixteen", 16},
{ "seventeen", 17},
{ "eighteen", 18},
{ "nineteen", 19},
{ "twenty", 20},
{ "twenty-one", 21},
{ "twenty-two", 22},
{ "twenty-three", 23},
{ "twenty-four", 24},
{ "twenty-five", 25},
{ "twenty-six", 26},
{ "twenty-seven", 27},
{ "twenty-eight", 28},
{ "twenty-nine", 29},
{ "thirty", 30},
{ "thirty-one", 31},
{ "thirty-two", 32},
{ "thirty-three", 33},
{ "thirty-four", 34},
{ "thirty-five", 35},
{ "thirty-six", 36},
{ "thirty-seven", 37},
{ "thirty-eight", 38},
{ "thirty-nine", 39},
{ "forty", 40},
{ "forty-one", 41},
{ "forty-two", 42},
{ "forty-three", 43},
{ "forty-four", 44},
{ "forty-five", 45},
{ "forty-six", 46},
{ "forty-seven", 47},
{ "forty-eight", 48},
{ "forty-nine", 49},
{ "fifty", 50},
{ "fifty-one", 51},
{ "fifty-two", 52},
{ "fifty-three", 53},
{ "fifty-four", 54},
{ "fifty-five", 55},
{ "fifty-six", 56},
{ "fifty-seven", 57},
{ "fifty-eight", 58},
{ "fifty-nine", 59},
{ "sixty", 60},
{ "sixty-one", 61},
{ "sixty-two", 62},
{ "sixty-three", 63},
{ "sixty-four", 64},
{ "sixty-five", 65},
{ "sixty-six", 66},
{ "sixty-seven", 67},
{ "sixty-eight", 68},
{ "sixty-nine", 69},
{ "seventy", 70},
{ "seventy-one", 71},
{ "seventy-two", 72},
{ "seventy-three", 73},
{ "seventy-four", 74},
{ "seventy-five", 75},
{ "seventy-six", 76},
{ "seventy-seven", 77},
{ "seventy-eight", 78},
{ "seventy-nine", 79},
{ "eighty", 80},
{ "eighty-one", 81},
{ "eighty-two", 82},
{ "eighty-three", 83},
{ "eighty-four", 84},
{ "eighty-five", 85},
{ "eighty-six", 86},
{ "eighty-seven", 87},
{ "eighty-eight", 88},
{ "eighty-nine", 89},
{ "ninety", 90},
{ "ninety-one", 91},
{ "ninety-two", 92},
{ "ninety-three", 93},
{ "ninety-four", 94},
{ "ninety-five", 95},
{ "ninety-six", 96},
{ "ninety-seven", 97},
{ "ninety-eight", 98},
{ "ninety-nine", 99},{ "hundred", 100}}
;

        public static int SayiyaCevirme(string numberString)
        {
            var numbers = Regex.Matches(numberString, @"\w+").Cast<Match>()
                .Select(m => m.Value.ToLowerInvariant())
                .Where(v => sayilar.ContainsKey(v))
                .Select(v => sayilar[v]);
            int acc = 0, total = 0;
            foreach (var n in numbers)
            {
                if (n >= 1000)
                {
                    total += (acc * n);
                    acc = 0;
                }
                else if (n >= 100)
                {
                    acc *= n;
                }
                else acc += n;
            }
            return (total + acc) * (numberString.StartsWith("minus",
                  StringComparison.InvariantCultureIgnoreCase) ? -1 : 1);
        }
        public static int NumberConversion(string numberString)
        {
            var numbers = Regex.Matches(numberString, @"\w+").Cast<Match>()
                .Select(m => m.Value.ToLowerInvariant())
                .Where(v => numberss.ContainsKey(v))
                .Select(v => numberss[v]);
            int acc = 0, total = 0;
            foreach (var n in numbers)
            {
                if (n >= 1000)
                {
                    total += (acc * n);
                    acc = 0;
                }
                else if (n >= 100)
                {
                    acc *= n;
                }
                else acc += n;
            }
            return (total + acc) * (numberString.StartsWith("minus",
                  StringComparison.InvariantCultureIgnoreCase) ? -1 : 1);
        }

    }
}


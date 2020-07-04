using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algolib
{
    public class Texts
    {
        public class Algorithms
        {
            /* Algorithms to do:
             * Aho-Corasick Algorithm for Pattern Searching
             * Manacher's Algorithm
             */

            /// <summary>
            /// Reverses a given text.
            /// </summary>
            /// <param name="text"></param>
            /// <returns></returns>
            public static string Reverse(string stext)
            {
                int n = stext.Length;
                char[] text = stext.ToCharArray();
                char tmp;
                for (int i = 0; i < (n + 1) / 2; i++)
                {
                    tmp = text[i];
                    text[i] = text[n - 1 - i];
                    text[n - 1 - i] = tmp;
                }
                return new string(text);
            }

            /// <summary>
            /// Returns the starting index of pattern matches in a text.
            /// 
            /// Time Complexity : O(n) to O(m*(n-m+1))
            /// </summary>
            /// <param name="stext"></param>
            /// <param name="spattern"></param>
            /// <returns></returns>
            public static int[] NaivePatternSearch(string stext, string spattern)
            {
                List<int> matches = new List<int>();
                if (spattern.Length == 0)
                {
                    return new int[] { -1 };
                }
                char[] text = stext.ToCharArray();
                char[] pattern = spattern.ToCharArray();
                int N = text.Length, M = pattern.Length;
                int i, j;
                // >>
                for (i = 0; i <= N - M; i++)
                {
                    for (j = 0; j < M; j++)
                    {
                        if (text[i + j] != pattern[j])
                        {
                            break;
                        }
                    }
                    if (j == M)
                    {
                        matches.Add(i);
                    }
                }
                // <<
                if (matches.Count == 0)
                {
                    return new int[] { -1 };
                }
                return matches.ToArray();
            }

            /// <summary>
            /// Knuth-Morris-Pratt (KMP) Pattern Search improves the worst case to O(n) unlike Naive approach.
            /// The trick is that if we know about characters that already match, we dont want to check them again.
            /// LPS tells us exactly where to start checking to help us skip the unneccessary checking process.
            /// </summary>
            /// <returns></returns>
            public static int[] KMPPatternSearch(string stext, string spattern)
            {
                List<int> matches = new List<int>();
                if (spattern.Length == 0)
                {
                    return new int[] { -1 };
                }
                char[] text = stext.ToCharArray();
                char[] pattern = spattern.ToCharArray();
                int N = text.Length, M = pattern.Length;
                // >>
                int[] lps = new int[M]; // LPS : Longest Prefix Suffix
                int j = 0; // pattern index

                KMPPatternSearchComputeLPS(pattern, M, lps);

                int i = 0; // text index
                while (i < N)
                {
                    if (text[i] == pattern[j])
                    {
                        i++; j++;
                    }

                    if (j == M)
                    {
                        matches.Add(i - j);
                        j = lps[j - 1];
                    }
                    else if (i < N && text[i] != pattern[j])
                    {
                        if (j != 0)
                        {
                            j = lps[j - 1];
                        }
                        else
                        {
                            i++;
                        }
                    }
                }
                // <<
                if (matches.Count == 0)
                {
                    return new int[] { -1 };
                }
                return matches.ToArray();
            }
            private static void KMPPatternSearchComputeLPS(char[] pattern, int M, int[] lps)
            {
                int len = 0;
                int i = 1;
                lps[0] = 0; // lps[0] is always 0

                // for i = 1 to M-1
                while (i < M)
                {
                    if (pattern[i] == pattern[len])
                    {
                        len++;
                        lps[i] = len;
                        i++;
                    }
                    else
                    {
                        if (len != 0)
                        {
                            len = lps[len - 1];
                        }
                        else
                        {
                            lps[i] = len;
                            i++;
                        }
                    }
                }
            }

            /// <summary>
            /// Like other pattern searching algorithms Rabin Karp iterates through the text one by one,
            /// but instead of checking the characters directly, first it calculates a hash value.
            /// If the hash values match then it starts checking the characters.
            /// 
            /// The Hash Function to be used here must be good because we have to calculate it for every substring of size M.
            /// That is what Rabin and Karp suggested, instead of calculating hash for every substring, we have a hash function that easily changes the value
            /// when 2 characters change, that is the first and last characters (because we are sliding over the text)
            /// </summary>
            /// <param name="stext"></param>
            /// <param name="spattern"></param>
            /// <returns></returns>
            public static int[] RabinKarpPatternSearch(string stext, string spattern)
            {
                List<int> matches = new List<int>();
                if (spattern.Length == 0)
                {
                    return new int[] { -1 };
                }
                char[] text = stext.ToCharArray();
                char[] pattern = spattern.ToCharArray();
                int N = text.Length, M = pattern.Length;
                // >>
                int q = 101; // a prime number
                int d = 256; // number of characters in the input alphabet
                int ht = 0;
                int hp = 0;
                int hash = 1;
                int i, j;

                for (i = 0; i < M - 1; i++)
                {
                    hash = (hash * d) % q;
                }

                // initial hash for text and actual hash of pattern
                for (i = 0; i < M; i++)
                {
                    hp = (d * hp + pattern[i]) % q; // pattern hash
                    ht = (d * ht + text[i]) % q; // text hash
                }

                // slide the pattern over the text
                for (i = 0; i < N - M; i++)
                {
                    // check if hash values match
                    if (hp == ht)
                    {
                        // if they do check if the characters match
                        for (j = 0; j < M; j++)
                        {
                            if (text[i + j] != pattern[j])
                            {
                                break;
                            }
                        }
                        if (j == M)
                        {
                            matches.Add(i);
                        }
                    }

                    // calculate the hash value of next substring (remove first, and add last character)
                    if (i < N - M)
                    {
                        ht = (d * (ht - text[i] * hash) + text[i + M]) % q;
                        // if we get a negaive value just convert it to positive
                        if (ht < 0)
                        {
                            ht = ht + q;
                        }
                    }
                }
                // <<
                if (matches.Count == 0)
                {
                    return new int[] { -1 };
                }
                return matches.ToArray();
            }

            /// <summary>
            /// This is Boyer Moore Algorithm with Bad Character Heuristic
            /// Boyer Moore Algorithm is a combination of two approaches:
            /// 1 - Bad Character Heuristic
            ///     The character of text which doesnt match with the current character of pattern is called Bad Character. 
            ///     In the case of a mismatch we do:
            ///     1.1 - Shift until mismatch becomes a match
            ///     1.2 - Shift until pattern moves past the mismatch character
            /// 2 - Good Suffix Heuristic
            /// 
            /// The problem to be tackled is same: Slide more than a single step to avoid unneccessary character checks.
            /// However Boyer Moore algorithm works from the last character to first.
            /// </summary>
            /// <param name="stext"></param>
            /// <param name="spattern"></param>
            /// <returns></returns>
            public static int[] BoyerMooreBCHPatternSearch(string stext, string spattern)
            {
                List<int> matches = new List<int>();
                if (spattern.Length == 0)
                {
                    return new int[] { -1 };
                }
                char[] text = stext.ToCharArray();
                char[] pattern = spattern.ToCharArray();
                int N = text.Length, M = pattern.Length;
                // >>
                int NO_OF_CHARS = 256;
                int[] badChar = new int[NO_OF_CHARS];

                BoyerMooreBadCharacterHeuristic(pattern, badChar);

                int s = 0; // shift of the pattern with respect to the text

                while (s <= (N - M))
                {
                    int j = M - 1;

                    // Keep reducing index j of pattern while charactes of pattern and text are matching at shift s.
                    while (j >= 0 && pattern[j] == text[s + j])
                    {
                        j--;
                    }

                    // If the pattern is presetnat current shift then index j wil become -1 after the above loop.
                    if (j < 0)
                    {
                        matches.Add(s);
                        /* Shift the pattern so that the next character in text aligns with the last occurence of it in pattern.
                         * The condition s+m < n is necessary for the case when pattern occurs at the end of the text.
                         */
                        s += (s + M < N) ? (M - badChar[text[s + M]]) : (1);
                    }
                    else
                    {
                        /* Shift the pattern so that the bad character in text aligns with the last occurence of it in pattern.
                         * The max function is used to make sure that we get a positive shift.
                         * We may get a negative shift if the last occurence of bad character in pattern is on the right side of the current character.
                         */
                        s += Math.Max(1, j - badChar[text[s + j]]);
                    }
                }
                // <<
                if (matches.Count == 0)
                {
                    return new int[] { -1 };
                }
                return matches.ToArray();
            }
            private static void BoyerMooreBadCharacterHeuristic(char[] str, int[] badChar)
            {
                int i;
                int NO_OF_CHARS = badChar.Length;
                int n = str.Length;
                // Initially -1
                for (i = 0; i < NO_OF_CHARS; i++)
                {
                    badChar[i] = -1;
                }
                // Fill the values with the last occurences of the characters
                for (i = 0; i < n; i++)
                {
                    badChar[str[i]] = i;
                }
            }

            /// <summary>
            /// This is Boyer Moore Algorithm with Good Suffix Heuristic
            /// Boyer Moore Algorithm is a combination of two approaches:
            /// 1 - Bad Character Heuristic
            ///     The character of text which doesnt match with the current character of pattern is called Bad Character. 
            ///     In the case of a mismatch we do:
            ///     1.1 - Shift until mismatch becomes a match
            ///     1.2 - Shift until pattern moves past the mismatch character
            /// 2 - Good Suffix Heuristic
            ///     Let t be the substring of text T which is matched with substring of pattern P.
            ///     1.1 - Shift the patten until another occurence of t in P matched with t in T
            ///     1.2 - A prefix of P which matches with suffix of t
            ///     1.3 - P moves past t
            /// The problem to be tackled is same: Slide more than a single step to avoid unneccessary character checks.
            /// However Boyer Moore algorithm works from the last character to first.
            /// </summary>
            /// <param name="stext"></param>
            /// <param name="spattern"></param>
            /// <returns></returns>
            public static int[] BoyerMooreGSHPatternSearch(string stext, string spattern)
            {
                List<int> matches = new List<int>();
                if (spattern.Length == 0)
                {
                    return new int[] { -1 };
                }
                char[] text = stext.ToCharArray();
                char[] pattern = spattern.ToCharArray();
                int N = text.Length, M = pattern.Length;
                // >>
                int s = 0, j;
                int[] bpos = new int[M + 1];
                int[] shift = new int[M + 1]; // initially 0

                BoyerMooreGoodSuffixHeuristic(shift, bpos, pattern);
                BoyerMooreGoodSuffixHeuristicCase2(shift, bpos, pattern);

                while (s <= N - M)
                {
                    j = M - 1;
                    // Keep reducing the index j of pattern while characters of pattern and text are matching at this shift s
                    while (j >= 0 && pattern[j] == text[s + j])
                    {
                        j--;
                    }
                    // If the pattern is present at the current shift then index j will become -1 at the above loop
                    if (j < 0)
                    {
                        matches.Add(s);
                        s += shift[0];
                    }
                    else
                    {
                        // pat[i] != pat[s+j] so shift the pattern j+1 times (to get to pat[s+j+1])
                        s += shift[j + 1];
                    }
                }
                // <<
                if (matches.Count == 0)
                {
                    return new int[] { -1 };
                }
                return matches.ToArray();
            }
            private static void BoyerMooreGoodSuffixHeuristic(int[] shift, int[] bpos, char[] pattern)
            {
                int m = pattern.Length;
                int i = m, j = m + 1;
                bpos[i] = j;

                while (i > 0)
                {
                    // if char at i-1 is not equal to char at j-1 then continue searching to the right of the pattern for border
                    while (j <= m && pattern[i - 1] != pattern[j - 1])
                    {
                        if (shift[j] == 0)
                        {
                            shift[j] = j - 1;
                        }
                        // Update the position of next border
                        j = bpos[j];
                    }
                    // p[i-1] matched with p[j-1], border is found. Store the beginning position of border.
                    i--; j--;
                    bpos[i] = j;
                }
            }
            private static void BoyerMooreGoodSuffixHeuristicCase2(int[] shift, int[] bpos, char[] pattern)
            {
                int i, j;
                j = bpos[0];
                for (i = 0; i <= pattern.Length; i++)
                {
                    // Set the border position of first character of pattern to all indices in array shift having shif[i] = 0
                    if (shift[i] == 0)
                    {
                        shift[i] = j;
                    }

                    // Suffix become shorter than bpos[0], use the position of next widest border as value of j
                    if (i == j)
                    {
                        j = bpos[j];
                    }
                }
            }

            /// <summary>
            /// Z Algorithm is a linear time pattern search algorithm. 
            /// It uses an additional array called Z, which is an array that stores the longest substrings starting from ith index.
            /// It also concates pattern and text, and because of this pattern becomes a suffix. 
            /// By putting a weird character in between such as $ we can just search for the occurences of substrings prefixes with length of pattern.
            /// 
            /// Time Complexity : O(n+m)
            /// </summary>
            /// <returns></returns>
            public static int[] ZPatternSearch(string stext, string spattern)
            {
                List<int> matches = new List<int>();
                if (spattern.Length == 0)
                {
                    return new int[] { -1 };
                }
                string concat = spattern + "$" + stext; // concatenated string is the trick of this algorithm
                int l = concat.Length;

                int[] Z = new int[l];
                ZPatternSearchGetZArray(concat.ToCharArray(), Z); // with another clever trick constructing Z is linear instead of quadratic

                for (int i = 0; i < l; ++i)
                {
                    if (Z[i] == spattern.Length)
                    {
                        matches.Add(i - spattern.Length - 1);
                    }
                }
                if (matches.Count == 0)
                {
                    return new int[] { -1 };
                }
                return matches.ToArray();
            }
            private static void ZPatternSearchGetZArray(char[] str, int[] Z)
            {
                int n = str.Length;
                int L, R, k;

                // [L, R] will be a window which matches with prefix of s
                L = R = 0;
                for (int i = 1; i < n; ++i)
                {
                    // If i>R nothing matches so we will calculate Z[i] naively
                    if (i > R)
                    {
                        L = R = i;
                        /* R-L = 0 in starting, so it will start checking from 0th index. For example for "ababab" and i=1
                         * the value of R reamins 0 and Z[i] becomes 0. For string "aaaaa" and i = 1 Z[i] and R both become 5.
                         */
                        while (R < n && str[R - L] == str[R])
                        {
                            R++;
                        }
                        Z[i] = R - L;
                        R--;
                    }
                    else
                    {
                        // k = i-L so k corresponds to the number which matches in [L,R] interval
                        k = i - L;

                        // If Z[k] is less than remaining interval then Z[i] will be equal to Z[k].

                        if (Z[k] < R - i + 1)
                        {
                            Z[i] = Z[k];
                        }
                        else
                        {
                            L = i;
                            while (R < n && str[R - L] == str[R])
                            {
                                R++;
                            }
                            Z[i] = R - L;
                            R--;
                        }


                    }
                }
            }

            /// <summary>
            /// Longest Common Subsequence is used heavily on science, computers and bioinformatics. 
            /// Thanks to dynamic programming we are able to calculate LCS using a bottom-up approach. 
            /// Using those same calculations, after finding the length of LCS we backtrack and get the actual LCS string.
            /// <example>
            /// T1: ABCDEF
            /// T2: AXYEKLF 
            /// LCS: AEF (order is important, contagiousness is not.)
            /// </example>
            /// </summary>
            /// <param name="sx"></param>
            /// <param name="sy"></param>
            /// <returns></returns>
            public static string LongestCommonSubsequenceDynamicProgramming(string sx, string sy)
            {
                int M = sx.Length;
                int N = sy.Length;
                char[] X = new char[M];
                char[] Y = new char[N];
                // Start
                int[,] L = new int[M + 1, N + 1]; // this is how our program will check previous computations, since it is Dynamic Programming

                // Build L in bottom up fashion, L[i][j] -> Length of LCS of X[0..i-1] and Y[0..j-1]
                for (int i = 0; i <= M; i++)
                {
                    for (int j = 0; j <= N; j++)
                    {
                        if (i == 0 || j == 0)
                        {
                            // Initialization condition (0-row and 0-col)
                            L[i, j] = 0;
                        }
                        else if (X[i - j] ==Y[j - 1])
                        {
                            // Go diagonal and increase by 1
                            L[i, j] = L[i - 1, j - 1] + 1;
                        }
                        else
                        {
                            // Right or left depending on previous LCS length to preserve the already-calculated LCS
                            L[i, j] = Math.Max(L[i - 1, j], L[i, j - 1]);
                        }
                    }
                }

                // Get lcs in string form
                int index = L[M,N]; // length of LCS is at the last slot of L matrix

                char[] lcs = new char[index]; // this will be our result

                int x = M, y = N;
                while ( x > 0 && y > 0 )
                {
                    // if characters are same it is a part of LCS
                    if (X[x-1] == Y[y-1])
                    {
                        lcs[index - 1] = X[x - 1]; // put current character in result char[]
                        x--; y--; index--;
                    }
                    // if characters are different go in the direction of the larger value of L[][]
                    else if (L[x-1,y] > L[x,y-1])
                    {
                        x--;
                    }
                    else
                    {
                        y--;
                    }
                }

                return new string(lcs);
            }

        } // end of class

        public class Puzzles
        {
            /// <summary>
            /// The task: Print every character but alternatively. Space included, and uppercase / lowercase are considered same.
            /// If you print a character, dont print the next occurences, but print the one after that, etc.
            /// 
            /// "STRING IGNORANCE"
            /// <example>
            /// It is a long day dear. === It sa longdy ear</example>
            /// </summary>
            /// <param name="text"></param>
            /// <returns></returns>
            public static char[] StringIgnorance(char[] text)
            {
                bool[] alph = new bool['Z' - 'A' + 1];
                for (int i = 0; i <= 'Z' - 'A'; i++)
                {
                    alph[i] = true;
                }
                bool printSpace = true;
                char[] newtext = new char[text.Length];
                int newtextPtr = 0;
                // iterate through the text
                for (int i = 0; i < text.Length; i++)
                {
                    if (!Char.IsLetter(text[i]))
                    {
                        if (printSpace || text[i] == '.')
                        {
                            newtext[newtextPtr++] = text[i];
                            printSpace = false;
                        }
                        else
                        {
                            printSpace = true;
                        }
                    }
                    else
                    {
                        int idx = Char.ToUpper(text[i]) - 'A';
                        if (alph[idx])
                        {
                            newtext[newtextPtr++] = text[i];
                            alph[idx] = false;
                        }
                        else
                        {
                            alph[idx] = true;
                        }
                    }
                }
                return newtext;
            }

            /// <summary>
            /// The input strings are lowercase words. Returns the number of characters that need to be removed to make the words anagram.
            /// Two words are anagram if they contain the same characters.
            /// 
            /// "ANAGRAM OF STRING"
            /// </summary>
            /// <param name="text1"></param>
            /// <param name="text2"></param>
            /// <returns></returns>
            public static int CharsToRemoveForAnagram(string text1, string text2)
            {
                int i, chars = 'Z' - 'A' + 1;
                int[] text1chars = new int[chars];
                int[] text2chars = new int[chars];
                int n1 = text1.Length, n2 = text2.Length;
                int count = 0;
                for (i = 0; i < n1; i++)
                {
                    text1chars[i]++;
                }
                for (i = 0; i < n2; i++)
                {
                    text2chars[i]++;
                }
                for (i = 0; i < chars; i++)
                {
                    count += Math.Abs(text1chars[i] - text2chars[i]);
                }
                return count;
            }

            /// <summary>
            /// Author: Erhan Tezcan
            /// Brings all permutations of the text with space in between characters
            /// 
            /// A comment on geeksforgeeks.com has been made about this solution.
            /// </summary>
            /// <param name="text"></param>
            /// <returns></returns>
            public static string[] GetPossibleStringsWithSpace(string text)
            {
                string[] ans = new string[(int)Math.Pow(2, text.Length - 1)]; int ans_i = 0;
                GetPossibleStringsWithSpaceR(text, 1, ref ans_i, ans);
                return ans;
            }
            private static void GetPossibleStringsWithSpaceR(string text, int i, ref int ans_i, string[] ans)
            {
                if (i < text.Length)
                {
                    GetPossibleStringsWithSpaceR(text, i + 1, ref ans_i, ans); // Dont put the space
                    GetPossibleStringsWithSpaceR(text.Substring(0, i) + " " + text.Substring(i), i + 2, ref ans_i, ans); // Put the space at i
                }
                else ans[ans_i++] = text;
            }

            /// <summary>
            /// Given a string of digits, find length of the longest substring of string such that the length of the
            /// substring is 2K digits and sum of left K digits is equal to sum right K digits.
            /// 
            /// There are many solutions to this:
            /// 1 - Naive Approach: Check every substring of even length. O(n^3)
            /// 2 - Dynamic Programming: Hold sums in a matrix. O(n^2) with space O(n^2)
            /// 3 - Dynamic Programming v2.: Hold cummulative sums in an array. O(n^2) with space O(n)
            /// 4 - Consider all possible mid points (of even length substrings) and keep exanding on both sides. 
            ///     Update the max value when the half sums are equal. O(n^2) with space O(1)
            /// </summary>
            /// <param name="stext"></param>
            public static int LongestEvenLengthOfSubstringHalfs(string stext)
            {
                int n = stext.Length;
                char[] text = new char[n];

                int ans = 0; // result
                for (int i = 0; i <= n - 2; i++)
                {
                    int l = i, r = i + 1;
                    // initalize left & right sum
                    int lsum = 0, rsum = 0;
                    while (r < n && l >= 0) // left is more than 0 and right is less than length
                    {
                        lsum += text[l] - '0';
                        rsum += text[r] - '0';
                        if (lsum == rsum)
                        {
                            ans = Math.Max(ans, r - l + 1);
                        }
                        l--;
                        r++;
                    }
                }
                return ans;
            }

        } // end of class
    } // end of class
} // end of namespace

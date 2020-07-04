package Algorithms;

import java.util.ArrayList;
import java.util.HashSet;
import java.util.Iterator;

public class NumberAlgorithms {

	public static boolean isOdd( int x ) {
		if ( x % 2 == 1 ) {
			return true;
		}
		else {
			return false;
		}
	}
	
	public static boolean isEven( int x ) {
		if ( x % 2 == 0 ) {
			return true;
		}
		else {
			return false;
		}
	}
	
	public static int[] getPrimeFactors_UNIQUE( int num ) {
		HashSet<Integer> factorsList = new HashSet<Integer>();
		int divider = 2;
		while ( num > 1 ) {
			if ( num % divider == 0 ) {
				num = num / divider;
				factorsList.add(divider);
			}
			else {
				divider++;
			}
		}
		int factors[] = new int[factorsList.size()];
		int p=0;
		for ( Integer i : factorsList ) {
			factors[p]=i;
			p++;
		}
		return factors;
	}
	
	public static int[] getPrimeFactors_ALL( int num ) {
		ArrayList<Integer> factorsList = new ArrayList<Integer>();
		int divider = 2;
		while ( num > 1 ) {
			if ( num % divider == 0 ) {
				num = num / divider;
				factorsList.add(divider);
			}
			else {
				divider++;
			}
		}
		int factors[] = new int[factorsList.size()];
		int p=0;
		for ( Integer i : factorsList ) {
			factors[p]=i;
			p++;
		}
		return factors;
	}
	
	public static int[] getPositiveDividers( int num ) {
		ArrayList<Integer> dividersList = new ArrayList<Integer>();
		for ( int i=1; i<=num/2; i++ ) {
			if ( num % i == 0 ) {
				dividersList.add(i);
			}
		}
		int dividers[] = new int[dividersList.size()+1];
		int p=0;
		for ( Integer i : dividersList ) {
			dividers[p]=i;
			p++;
		}
		dividers[p]=num;
		return dividers;
	}
	
	public static int[] getPositiveProperDivisers( int num ) {
		ArrayList<Integer> dividersList = new ArrayList<Integer>();
		for ( int i=1; i<=num/2; i++ ) {
			if ( num % i == 0 ) {
				dividersList.add(i);
			}
		}
		int dividers[] = new int[dividersList.size()];
		int p=0;
		for ( Integer i : dividersList ) {
			dividers[p]=i;
			p++;
		}
		return dividers;
	}
	
	public static int numberOfPrimesUpToNumber_NLOGN( int num ) {
		return (int)( num / Math.log(num) );
	}
	
	public static double logBaseB( int base, double num ) {
		if ( num>1 ) {
			return ( Math.log(num)/Math.log(base) );
		}
		else {
			return -1;
		}
	}
	
	public static int[] allPrimesUpToNumber_ERATOSTHENES( int num ) {
		int[][] numbers = new int[2][num+1];
		int primecount=0;
		for ( int i=0; i<=num; i++ ) {
			numbers[0][i]=i+1;
		}
		numbers[1][0]=1;
		numbers[1][1]=1;
		for ( int i=1; i<=num; i+=2 ) {
			if ( numbers[1][i]==0 ) {
				primecount++;
				for ( int j=i*i; j<=num; j+=i ) {
					numbers[1][j]=1;
				}
			}
		}
		int[] primes = new int[primecount];
		primecount=0;
		for ( int i=0; i<=num; i++ ) {
			if ( numbers[1][i]==1 ) {
				primes[primecount]=i;
				primecount++;
			}
		}
		return primes;
	}
	
	public static int[] allPrimesUpToNumber_ISPRIME( int num ) {
		ArrayList<Integer> primesList = new ArrayList<Integer>();
		for ( int i=2; i<=num; i++ ) {
			if ( isPrime(i) ) {
				primesList.add(i);
			}			
		}
		int primes[] = new int[primesList.size()]; 
		int p=0;
		for ( Integer i : primes ) {
			primes[p]=i;
			p++;
		}
		return primes;
	}
	
	public static int getNumberOfOddElementsInAlliquotSum(int num ) {
		int[] factors = getPositiveProperDivisers(num);
		int odds=0;
		for ( int i=0; i<factors.length; i++ ) {
			if ( factors[i] % 2 == 1 )
				odds++;
		}
		return odds;		
	}
	
	public static int getNumberOfPrimeFactors( int num ) {
		int[] primes = getPrimeFactors_ALL(num);
		return primes.length;
	}
	
	public static int greatestCommonFactor( int num1, int num2 ) { // EBOB
		int res=Math.abs(num1-num2);
		while ( res!=0 ) {
			res = Math.abs(num1-num2);
			if ( res < num2 ) {
				num2 = res;
			}
			else {
				num1 = res;
			}
		}		
		return num1;
	}
	
	public static int leastCommonMultiple( int num1, int num2 ) { // EKOK
		return num1 * num2 / greatestCommonFactor(num1, num2);
	}
	
	public static boolean isPerfectNumber( int num ) {
		if ( getAlliquotSum(num) == num ) {
			return true;
		}
		else {
			return false;
		}
	}
	
	public static boolean isAbundantNumber ( int num ) {
		if ( getAlliquotSum(num) > num ) {
			return true;
		}
		else {
			return false;
		}
	}
	public static boolean isDeficientNumber ( int num ) {
		if ( getAlliquotSum(num) < num ) {
			return true;
		}
		else {
			return false;
		}
	}
	
	public static int getAlliquotSum( int num ) {
		int sum=0;
		int divisors[] = getPositiveProperDivisers(num);
		for ( int i : divisors ) {
			sum += i;
		}
		return sum;
	}
	
	public static boolean isPerfectSquare( int num ) {
		double d; int i;
		d = Math.sqrt(num);
		i = (int) Math.sqrt(num);
		if ( d==i ) {
			return true;
		}
		else {
			return false;
		}
		
	}
	
	public static boolean isPrime(int n) {
        if (n <= 1) {
            return false;
        }
        if (n == 2) {
            return true;
        }
        if (n % 2 == 0) {
            return false;
        }
        for (int i = 3; i <= Math.sqrt(n) + 1; i = i + 2) {
            if (n % i == 0) {
                return false;
            }
        }
        return true;
    }
	
	public static int numberOfPerfectSquaresUpTo( int num ) {
		return (int) Math.sqrt(num);
	}
	
//	public static boolean isKaprekarNumber( int num ) {
//		
//	}
	
//	public static boolean isHarshadNumber( int num ) {
//		
//	}
	
	public static boolean areAmicableNumbers( int num1, int num2 ) {
		int dividers1[] = getPositiveProperDivisers(num1);
		int dividers2[] = getPositiveProperDivisers(num2);
		int sum1=0, sum2=0;
		for ( int i : dividers1 ) {
			sum1+=i;
		}
		for ( int i : dividers2 ) {
			sum2+=i;
		}
		if ( (sum1==num2) && (sum2==num1) ) {
			return true;
		}
		else {
			return false;
		}	
		
	}
	
	public static boolean areFriendlyNumbers( int num1, int num2 ) {
		int dividers1[] = getPositiveDividers(num1);
		int dividers2[] = getPositiveDividers(num2);
		double sum1=0, sum2=0;
		for ( int i : dividers1 ) {
			sum1+=i;
		}
		for ( int i : dividers2 ) {
			sum2+=i;
		}
		sum1 = sum1 / num1;
		sum2 = sum2 / num2;
		if ( sum1==sum2 ) {
			return true;
		}
		else {
			return false;
		}
		
	}
	
	public static int shiftingMultiply(int a, int b) {
		int res=0;
		while ( a!=0 ) {
			res+= b * ( a % 2 );
			a = a>>1;
			b = b<<1;
		}
		return res;
	}
	
	public static int getDigitCount(int num) {
	    int count=0;
	    while ( num>0 ) {
	        num = num / 10;
	        count++;
	    }
	    return count;
	}
	
	public static int getDigit( int num, int digitNo ) {
	    if ( digitNo<=0 || digitNo>getDigitCount(num) ) {
	        return -1;
	    }
	    else {
	       int div10=1, mod10=1;
	       for ( int i=0; i<digitNo; i++ ) {
	           mod10*=10;
	           div10*=10;
	       }
	       div10/=10;
	       num = num % mod10;
	       num = num / div10;
	       return num;
	    } 	    
	}
	
	public static int reverseNumber( int num ) {
		int newnum=0;
		for ( int i=1; i<=getDigitCount(num); i++ ) {
			newnum*=10;
			newnum+=getDigit(num, i);
		}
		return newnum;		
	}
	
	
	
	
}

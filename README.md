
# **[NumberGuessingGame](https://github.com/Zelong-Yu/NumberGuessingGame)**

### Zelong Yu
A console program as practice of binary search.

![Alt text](Sample.gif?raw=true "Sample Run")

Answers and Comments:
-----------------------------
**Implement bisection algorithm**
A binary search method is implemented. Verbose option is given to have the app print each step.  User input is validated to guard against FormatException, ArgumentOutOfRangeException (when user selected number is out of range) and OverflowException.  If user input is empty or whitespaces, default value will be used. 

**Guess my number, human plays**
Average number of repetitions necessary for me to guess the number: 12, when I am not careful enough. 
When I can careful enough, the maximum number of guesses I need to guess a number between 1 and 1000 is 10, since we at most need log2 1000~9.966 round up to 10 guesses. 

**Guess my number, computer plays**

|Actual value        |  Guesses Perform |    
|---------------------|------------------| 
|1                    |6                 |
|100                  |7                 |
|33                   |7                 |  

Average needed is 7 times since I pick the hardest cases. Since 100 is between 2^6^=64 and 2^7^ =128 it needs at most 7 guesses. 

Is the human as good as the computer in finding the number? Well yes only if we are careful enough to perform the binary search... but can't beat the computer. 

If it is just for lookup (check is an element is in a list), when using data structure like HashSet the computer do it in constant time O(1) (well, O(N) in worst case but rarely happens). No one can beat that. 


## Getting started

First decide how the programmer is going to enter the program.  

* Will they be entering it one line at a time at a command prompt.  (Like an interpreter )
* Will your program being reading in the lines from a text file.

Then you need to decide how you are going to parse the commands.

* String functions,  for example `if (command.StartsWith("Ask"))`
* Regular Expressions, for example `^Ask (?<who>(Tinky Winky)|(Dipsy)|(Laa Laa)|(Po))$`
* Using a parsing library/tool

Then implement the `Is` and `Ask` commands for single Teletubby.  Once they are working make they work with the other three Teletubbies.

Work your way down the list of commands,  they get more complex towards the end!

Feel free to write additional/different commands.  I would recommend keeping them easy to parse.

---

## Teletubbies
There are four different Teletubbies
1.   Tinky Winky
2.   Po
3.   Laa Laa
4.  Dipsy

This can be thought of as 4 string variables.

---

## Commands

### Is
The `Is` command is used to give a value to a Teletubby

Examples: 

* `Laa Laa is Green`
* `Po is 42`

---
### Ask
The `Ask` command is used to display the value currently held by a Teletubby

Examples

* `Ask Po`        =>  _Po says 42_
* `Ask Laa Laa`   =>  _Laa Laa says Green_

---
### Speaks To
The `speaks to` command is used to give a value from one Teletubby to another.

Example

`Po is 42`    
`Po speaks to Tinky Winky`            
`Ask Tinky Winky`  => _Tinky Winky says 42_

---
### Whisper
The `whisper` command is used to give a lower cased value from one Teletubby to another.

Example

`Po is RED`    
`Po whispers to Tinky Winky`            
`Ask Tinky Winky`  => _Tinky Winky says red_

---
### Yells
The `yell` command is used to give an upper cased value from one Teletubby to another.

Example

`Po is blue`    
`Po yells to Tinky Winky`            
`Ask Tinky Winky`  => _Tinky Winky says BLUE_

---
### Tell
The `tell` command is used to provide a user inputted value to a Teletubby

Example

`Tell Po your name`    
_Po asks what is your name?_ __David__       
`Ask Po`  => _Tinky Winky says David_

---
### Gets bigger
The `gets bigger` command is used to increase a value held by a teletubby.

Example

```
Dipsy is 40
Dispy gets bigger
Ask Dispy  => Dipsy says 41
```

---
### Gets samller
The `gets smaller` command is used to decrease a value held by a teletubby.

Example

```
Dipsy is 40
Dispy gets smaller
Ask Dispy  => Dipsy says 39
```


---
## Conditions (Harder)

### Bedtime is when
The `Bedtime is when` command is used to define a condition

Example

`Bedtime is when Dipsy is 5`    
`Bedtime is when Po is David`    

---
### Is it Bedtime?
The `Is it Bedtime?` command is used to evaluate a condition

Example

`Is it Bedtime?`    => _Yes_


---
### If it is Bedtime then
Allows a command to only be evaluated when the condition is true

Example

```
Po is 5
Bedtime is when Po is 6
Ask Po  => _Po says 5_
If it is BedTime then Po is 7
Ask Po  => _Po says 5_
Bedtime is when Po is 5
If is it BedTime then Po is 7
Ask Po  => _Po says 7_
```

---
## Loops (Advanced)
The complication is you now need to be able to support multi-line statements

```
Bedtime is when Po is 6
Po is 1
Laa Laa is 10
Play until Bedtime
    Po gets bigger
    Laa Laa gets smaller
Ask Po => Po says 6
Ask Laa Laa => Laa Laa says 4
```

An alternative would be to implement a form of go-to statement
```
Bedtime is when Po is 6
Po is 1
Laa Laa is 10
This is the playground
Po gets bigger
Laa Laa gets smaller
If it is not BedTime then go to the playground
Ask Po => Po says 6
Ask Laa Laa => Laa Laa says 4
```
# Bank application.
## ThePenguinBank
#### Thank you for using The Penguin Bank Application
##### PLEASE NOTE: 
Since we want the source code to be as easy as possible to read, we have added our logotype in a separate file that adds to your
local folder, so the FIRST thing we ask you to do is go in to the class called: Methods 
and on the absolute bottom of the page you will find a string datatype: 
string path = @" HERE you need to add your directory, ex: C:\Users\youruser\source\repos\ThePenguinBank\PenguinLogo.txt";
Otherwise the logo won't appear.

Then you can launch the app and you will have to enter some login details. We have created three pre-made login accounts for you to use. You will be able to add 
new customer accounts if you use the admin login details. 
### Admin user:
CustomerID = 11111
Password = 0000
### Pre-made customer 1:
CustomerID = 8808227832
Password = 123
### Pre-made customer 2:
CustomerID = 9907139100
Password = 321
#### PLEASE NOTE, you only have 3 attempts at enter the correct login details before the app shut's down.
We have also already added 4 different account's that are connected to 2 pre-made "dummy" customers for the best testing 
experience of the app. You will ofc be able to add as many new account's of various types on your own. But since there are 
funtioncs in the app that let you take a look at all the accounts and make transfers between balances, we added a few for you to test with and so you can see some data in the app from start if you dosn't want to add or play with the functions. 
(You will be able to see these account's via the menu)

### MENU
After you have logged in you will see the menu. There is one menu for Admin with all the functions that only the admin is 
supposed to be able to do.
The Customer menu have several more choice's since this is an app for the customer in first hand.
You can always log off from the menu and will then return to the login screen again. 

### Source code
We chose to create 8 classes as the basic structure of our code:
- Program Class: contains only the main method were we run our app
- Customer Class: contains 4 methods
- Admin Class: contains 6 methods
- Account Class: the only abstract class
- Checking Class: contains 1 method
- Saving Class: contains 1 method
- Loan Class: contains 1 method
- Methods Class: contains 5 methods

### Meaning
CustomerID - represent your personal security number (in Sweden it's your DoB+4 digits)
AccountID - nothing you can chose, this will be set automaticlly by the app
Balance - this is your account balance, the standard currency is SEK.
Name - well, your name..


#### The Pixel Penguin Team:
##### -> Angelica Lindström
##### -> Caroline Uthawong-Burr
##### -> Emil Nordin
##### -> Theres Sundberg Selin
##### -> Zia Nourozi






















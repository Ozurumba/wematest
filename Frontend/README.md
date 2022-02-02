# angular-10-registration-login-database

## Problem statement
 
Build an application that should Enable customer's onboard to a Mock Bank. The application should have three Interfaces as described below
 
 1. Registration Interface : This interface should have three sections . Biodata(First Name, Last Name Phone Number , Email, state of origin, LGA and age) section, Business Details ( Business name, Business Reg Number, List of directors and business email address) session and Personal documentation (Upload selfie and upload signature) section. upon saving of customer details , he should be redirected to a dashboard
 
2. Dashboard Interface : This should be a simple screen that displays welcome message to users and also a tab or menu for the user to navigate to transaction History
 
3. Transaction Interface: This should be seen from the dashboard, and it should display mock transactions with the following headers
 a. Transaction Reference
 b. Transaction Date
 c. Transaction status
 d. Transaction Amount
 
## Acceptance Criteria
 
1. Use asp dotnet MVC and angularJs with typescript where applicable for the application
 
2. Use bootstrap for your css designs
 
3. Ensure that you demonstrate best engineering practice when you can in the implementation
 
4. A chosen state should drive the LGA a customer can see (you must not reflect all LGA and states in Nigeria , just use few records to illustrate the concept)
 
5. Ensure that all inputs are validated to best standard.
 
6. customers should not be able to upload files of size 0k
 
## Business Rules
 
A customer below age 18 should not be onboarded but be presented with a pop with the message "Only customer of age 18 and above can be onboarded".
If a customer submits an image above 1mb the customer should get a pop up suggesting how to reduce the size of the image.
Customer must provide information in BIO DATA and Personal document, but business detail should be optional for a customer to be onboarded.

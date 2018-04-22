# Theme Park Management System

### COSC 3380 – Design of File and Database Systems – Spring Semester 2018
### Group 11 - Matthew Potter, Jeffery Pernia, Diego Perez, Brandon Le, Joby Santhosh

Scenario
-----
To manage information about a specific theme park and collect data including number of customers and average number per month; average number of rides broken down / needing maintenance; most frequently ridden rides per month; number of rainouts per month (and which month); spikes in average number of customers on a weekly and monthly basis, etc.

To do
-----
1. user login, different types of users, authentication
    * https://code.msdn.microsoft.com/ASPNET-MVC-5-Security-And-44cbdb97
    * https://weblog.west-wind.com/posts/2015/Apr/29/Adding-minimal-OWIN-Identity-Authentication-to-an-Existing-ASPNET-MVC-Application#MinimalCodeSummary
    * https://www.asp.net/aspnet/overview/owin-and-katana
2. ~allow data entry/updates~
3. ~triggers to put in, active processes (at least one, more better ?)~
    * https://www.codeproject.com/Articles/38808/Overview-of-SQL-Server-database-Triggers
    ~* when maintenance caseID is created, set appropriate ride isOpen to false~
4. reports
    * GUESTS_SHOPS - date parameter to see popularity during given date ranges
    * GUESTS_RIDES - date parameter to see popularity during given date ranges
    * GUEST and TICKET - a list with guest and corresponding ticket info that can also be given a date range
    * Create graphs to show spikes in avg guests 
        * https://docs.microsoft.com/en-us/aspnet/web-pages/overview/data/7-displaying-data-in-a-chart
5. fix null values in the dbms
6. ~add Rides, Shops, Staff, and Guests views~
    * https://docs.microsoft.com/en-us/aspnet/mvc/overview/getting-started/introduction/adding-a-view
7. additional functionality
    * bad weather - if isOutside then increment RainOutCount
    * when updating item/ride price - create new item/ride ID
    * when Guest_Shops is created, subtract quantity from productstock of appropriate item
    ~* when maintenance caseID is created, set appropriate ride isOpen to false~
    * when endtime is initialized, set appropriate ride isOpen to true
    * add reference tables for employeetype, tickettype, shoptype

Helpful Links
-----
* https://www.tutorialspoint.com/entity_framework/index.htm

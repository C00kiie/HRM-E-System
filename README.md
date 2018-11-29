# HRM-E-System
An HR-Management system targeted towards teams/tasks driven companies.

How to install:

1- run migrations:
     make sure to go to app.config, Change Data source to your specified MS SQL Server, 
     and then go to package-manager and run update-database.
            connectionString="Data Source=[data source (without the brackets)];Integrated Security=SSPI;database=HRM_DB_v1;" providerName="System.Data.SqlClient" />

2- Compile & Run


3- Make a department using the once-only button "Create Department", then register an employee with a manager permission,
     and assign it to the department in which you've created.
     
Doing these steps will ensure running all features fluently.

Features:

1- Departments: A department may have multiple employees and managers
2- Tasks: A task may be given by a department manager to his department employees.
3- Attendence & Holidays: an employee may register his attendence, request holidays so that it'd be accepted/rejected by 
  his department manager.
4 - Employee Management: an employee can be deactivated/activated, removed. You can view each employee attendance & holidays requests, 
                         tasks.
5 - Permissions: each employee will have different functionalities which will be determined upon his given role.

Bugs: most of the bugs are view-front-end bugs.

- in manage employees view, when viewing attendance/tasks it'll be actually viewed as if you are the employee itself i.e you can do the
  same functionalities as if you are the user it self
- Not actually a bug, but some views require pressing a "refersh" button to reload the data. 
- The view greatly handicaps the database with queries i.e it may query the db more than needed.

All of these bugs are the result of a badly-written front-end views code, and some architectual decisions, like not implementing 
observable objects, which would have been greatly useful but sadly I didn't know about them and I needed it when I have actually
finished my codebase -- however in my humble opinion the backend codebase is quite neat and adjustable,  and may fit the market 
needs given we have a proper knowledge of the use case.



Thanks to:
* Seif Amar for being patient & understanding.
* Ahmed Aljaf for giving his sweet social-workarea & soft-skills advices.
* Wael for explaining MVVM like a pro.


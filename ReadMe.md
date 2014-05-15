How to install
==============
* Ensure Microsoft .Net framework 4 or 4.5 is installed on the client machine.
    * If your runtime environment has "client profile" in the name (in the Add/Remove programs list), this utility will not work. 
* The utility does not require an "installation" program to be run, it will work out of the box as long as the accompanying dll files are stored next to the exe.
* Copy the contents of the zip file to a folder on the C: drive (or optionally, on a network share)
* To run the utility, launch "SKGovAtt.exe". The first time it is run it will prompt for a database connection string


Database connection information
===============================
This utility requires access to the SchoolLogic database. Depending on how your organization handles SQL server access, you may also need a database administrator to create you an account on the SQL server, and grant you access to the SchoolLogic database.

Regardless of how you access the database, your database administrator should give you *read only* access only. This utility does not need to write to the database.

If you are having difficulty getting a connection string working, you may find some help at http://www.connectionstrings.com/sql-server/. 

Microsoft .Net Framework issues
===============================
This utility requires Microsoft .Net version 4 or 4.5, but it cannot be a "client profile" version of the runtime environment. This is because the third party library that the utility uses to create Excel documents (EPPlus) requires access to the System.Web libraries, which are not available in "client profile" versions. Microsoft has moved away from "client profile" versions since 4.5, so the easiest way to prevent problems is simply installing the newest version of the .Net runtime environment.

License
=======
You are free to use, redistribute and/or modify this utility as you see fit.
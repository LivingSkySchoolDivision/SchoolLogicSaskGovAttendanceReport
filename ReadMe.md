Download link (GitHub)
=========================
See [releases](https://github.com/LivingSkySchoolDivision/SchoolLogicSaskGovAttendanceReport/releases/latest) for ready to use copies of this program.


How to install
==============
**NOTE: You will need the help of your IT department to configure this utility the first time.**

* Ensure Microsoft .Net framework 4 or 4.5 is installed on the computer.
    * If your runtime environment has "client profile" in the name (in the Add/Remove programs list), this utility will not work. You will need to update to .Net 4.5 to fix this.
* The utility does not require an "installation" program to be run, it will work out of the box as long as all the included files are in the same folder.
* Copy the contents of the zip file to a folder on the C: drive (or optionally, on a network share). I recommend creating a new folder on your C: drive called "SKGovAtt", and expanding the zip file into that.
* To run the utility, launch "SKGovAtt.exe". The first time it is run it will prompt for a database connection string.

The utility is designed to be used by non-sysadmins once it has been configured. As long as the database connection string works, any user who can push a button should be able to generate the file.


Database connection information
===============================
This utility requires access to the SchoolLogic database. Depending on how your organization handles SQL server access, you may also need a database administrator to create you an account on the SQL server, and grant you access to the SchoolLogic database.

Regardless of how you access the database, your database administrator should give you *read only* access only. This utility does not need to write to the database.

If you are having difficulty getting a connection string working, you may find some help at http://www.connectionstrings.com/sql-server/.


Potential security issues
=========================
This utility stores the database connection string in plain text in it's config file (the file has extension ".config"). If your connection string includes a username and password, anyone with access to the config file will be able to see it.

I recommend creating a new SQL user with read-only access and a complex password, and only using this user account with this utility. You should also protect the ".config" file from being accessed by users who don't need to use this utility - especially if you intend to run this utility from a Windows share.

This utility will not attempt to write to the SQL database, but if someone malicious obtains the username and password from your connection string, they can do serious damage to the database if the SQL user has anything other than read only access.


License
=======
You are free to use, redistribute and/or modify this utility as you see fit.

Download link (BitBucket)
=========================
Download a compiled ready-to-go version here: https://bitbucket.org/livingskyschooldivision/sask-government-attendance-report-generator-for-schoollogic/downloads/SKGovAtt_Compiled.zip

How to install
==============
**NOTE: You will need the help of your IT department to configure this utility the first time.**

* Ensure Microsoft .Net framework 4 or 4.5 is installed on the computer.
    * If your runtime environment has "client profile" in the name (in the Add/Remove programs list), this utility will not work. You will need to update to .Net 4.5 to fix this.
* The utility does not require an "installation" program to be run, it will work out of the box as long as all the included files are in the same folder.
* Copy the contents of the zip file to a folder on the C: drive (or optionally, on a network share). I recommend creating a new folder on your C: drive called "SKGovAtt", and expanding the zip file into that.
* To run the utility, launch "SKGovAtt.exe". The first time it is run it will prompt for a database connection string.

You do not need to install this on a server - it is designed to be run from a workstation. You may experience slowness if your connection to the database server is less than 10mbps.

The utility is designed to be used by non-sysadmins once it has been configured. As long as the database connection string works, any user who can push a button should be able to generate the file.


Database connection information
===============================
This utility requires access to the SchoolLogic database. Depending on how your organization handles SQL server access, you may also need a database administrator to create you an account on the SQL server, and grant you access to the SchoolLogic database.

Regardless of how you access the database, your database administrator should give you *read only* access only. This utility does not need to write to the database.

If you are having difficulty getting a connection string working, you may find some help at http://www.connectionstrings.com/sql-server/. 

Microsoft .Net Framework issues
===============================
This utility requires Microsoft .Net version 4 or 4.5, but it cannot be a "client profile" version of the runtime environment. This is because the third party library that the utility uses to create Excel documents (EPPlus) requires access to the System.Web libraries, which are not available in "client profile" versions. Microsoft has moved away from "client profile" versions since 4.5, so the easiest way to prevent problems is simply installing the newest version of the .Net runtime environment.

Using the source code
=====================
You can clone this repository to your computer if you have Mercurial installed, by typing the following:
    
    hg clone https://bitbucket.org/livingskyschooldivision/sask-government-attendance-report-generator-for-schoollogic

 You can also download the source code from this repository from the "Downloads" link (likely on the left side of this page if you are reading this on bitbucket).

 You should only need Visual Studio to compile - I used Visual Studio 2012, but any recent version should also work.

Credits
=======
This utility was created by Mark Strendin (mark.strendin@lskysd.ca) of Living Sky School Division No. 202, in North Battleford Saskatchewan. If you have issues or feedback, feel free to contact me, though I can't guarantee that I'll answer.

License
=======
You are free to use, redistribute and/or modify this utility as you see fit.
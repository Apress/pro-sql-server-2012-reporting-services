-----------------------------------------------------------------------------------------
-    Pro SQL Reporting Services 2012     						-
-  	Database Restores and Source File Usage Instructions  				-
-  	Brian McDonald, Shawn McGeHee and Rodney Landrum				-
-----------------------------------------------------------------------------------------

	In order to run the reports used in this book, you will need to restore the
	Pro_SSRS, Pro_SSRSExecutionLog and the HW_Analysis databases from the root folder 
	of this download to your instance of SQL Server (SS) 2012. The main database that
	is used throughout the book is the Pro_SSRS database. Another database introduced
	in Chapter 10 is the Pro_SSRSExecutionLog. This database is used to pull data from
	our ReportServer database using the SSIS Project(RSExecutionLog_Load). In 
	Chapter 12, we include a datamart database called HW_Analysis to populate an 
	Analysis Services cube called Patient Referral. You can use the following 
	instructions below to attach all four databases. To restore/deploy the Patient 
	Referral cube, follow the instructions for "Restoring the Patient Referral Cube" 
	section of this document.

	Finally, there is one other database that is part of the Pro SQL Reporting 
	Services 2012 book. To properly show Report Models and Report Builder 1.0, 
	which cannot be created using SQL Server Data Tools/Business Intelligence 
	Development Studio, we created a small subset of the Pro_SSRS database 
	appropriately named Pro_SSRS_2008R2. If you follow along with the Report 
	Model and Report Builder 1.0 examples in Chapter 13, we have used a different 
	VM that contains SQL Server 2008 R2. Details on restoring this version of the 
	DB are in the section below.


*****************************************************************************************
*    Restoring the Pro_SSRS, Pro_SSRSExecutionLog, HW_Analysis				*
*    and Pro_SSRS2008R2 databases 							*
*****************************************************************************************

-----------------------------------------------------------------------------------------
-- Pro_SSRS (Used throughout the book)
-----------------------------------------------------------------------------------------
	1.) Extract the contents of the zip file to a location available to your SQL 
    	Server 2012 system.
	2.) If you are using Winzip, make sure you select to "Use Folder Names".
	3.) On your SS 2012 server, open SS Management Studio.
	4.) Connect to your server, navigate to Databases, right click the Databases 
	    folder and select Restore Database. The database must be named Pro_SSRS
	5.) If you are using Enterprise or Developer Editions, select "From Device" and 
	    navigate to the Pro_SSRS.bak file you extracted in step 1. If you are using 
	    any other versions of SQL Server 2012, please use the Pro_SSRS_NoCompression.bak.
	    NOTE: Both databases are the same, but compression was enabled on the 
            Pro_SSRS.bak database backup file.	
	6.) Click OK and the database should restore successfully and be ready for use 
    	throughout the book.

	*** Note: The database must be named Pro_SSRS for the examples to work

-----------------------------------------------------------------------------------------
-- Pro_SSRSExecutionLog (Used in Chapter 10)
-----------------------------------------------------------------------------------------
	1.) Extract the contents of the zip file to a location available to your SQL 
    	    Server 2012 system.
	2.) If you are using Winzip, make sure you select to "Use Folder Names".
	3.) On your SS 2012 server, open SS Management Studio.
	4.) Connect to your server, navigate to Databases, right click the Databases 
    	    folder and select Restore Database. The database must be named 
    	    Pro_SSRSExecutionLog
	5.) Select "From Device" and navigate to the Pro_SSRSExecutionLog.bak file you 
    	    extracted in step 1.
	6.) Click OK and the database should restore successfully and be ready for use 
    	    for Chapter 10 of the book.


	*** Note: The database must be named Pro_SSRSExecutionLog for the examples to work

-----------------------------------------------------------------------------------------
-- HW_Analysis (Used in Chapter 12)
-----------------------------------------------------------------------------------------
	1.) Extract the contents of the zip file to a location available to your SQL 
    	    Server 2012 system.
	2.) If you are using Winzip, make sure you select to "Use Folder Names".
	3.) On your SS 2012 server, open SS Management Studio.
	4.) Connect to your server, navigate to Databases, right click the Databases 
	    folder and select Restore Database. The Database name must be HW_Analysis
	5.) Select "From Device" and navigate to the HW_Analysis.bak file you extracted 
	    in step 1.
	6.) Click OK and the database should restore almost immediately as it is fairly 
	    small.

	*** Note: The database must be named HW_Analysis for the examples to work 


-----------------------------------------------------------------------------------------
-- Pro_SSRS_2008R2 (Used in Chapter 13 only)
--
-- ** THIS MUST BE ON A SQL SERVER 2008 R2 INSTANCE. REPORT MODELS, AS YOU WILL
-- LEARN IN CHAPTER 13 HAVE BEEN DEPRECATED AND CANNOT BE CREATED USING BIDS AND
-- SQL SERVER 2012. HOWEVER, THEY CAN STILL BE USED AS DATA SOURCES AND AS SUCH
-- WE HAVE COVERED THEM AS PART OF THIS RELEASE. **
-----------------------------------------------------------------------------------------
	1.) Extract the contents of the zip file to a location available to your SQL 
	    Server 2008 R2 system. Since the other backup files (.bak) are for the 2012
	    databases, you can remove them from this folder. Also, the Pro_SSRS Reporting
	    Services solution will not work on a 2008 R2 instance, so you can remove
	    that as well. If you already have the zip file extracted to another server,
	    you could just move the Pro_SSRS_2008R2.bak file from the 2012 system over
	    to your 2008 R2 system. The choice is yours. 
	2.) If you are using Winzip, make sure you select to "Use Folder Names".
	3.) On your SS 2008 R2 server, open SS Management Studio.
	4.) Connect to your server, navigate to Databases, right click the Databases 
	    folder and select Restore Database. The database must be named Pro_SSRS_2008R2
	5.) Select "From Device" and navigate to the Pro_SSRS_2008R2.bak file you extracted 
	    in step 1.
	6.) Click OK and the database should restore successfully and be ready for use 
	    throughout the book.

	*** Note: The database must be named Pro_SSRS_2008R2 and on a 2008R2 instance
	for the examples to work


*****************************************************************************************
* 	Setting Up the Pro_SSRS Solution 						*
*****************************************************************************************

	All of the reports and content from Chapters 3, 4, 5, 6, 10, 12 and 13 (Report 
	Part) can be found in the Pro_SSRS Project solution in the download. Simply 
	extract the entire zip file to a location on your local hard drive, preferrably 
	c:\Pro_SSRS_Project maintaining the folder structure in the zip file. For 
	Chapters 7, 8, 9 and the last part of 10, the code will be located in a 
	separate solution and added from the zip to folders named after the chapters, 
	"Chapter 7" for example. You can open the solution for each of the chapters 
	for 7, 8, 9 and 10 where applicable. All of the report files (RDLs) will be 
	contained in the solutions provided and referenced in the text of the book.


	*** Note: For Chapters 8 and 9, there is a referenced report, Daily Activity, 
	but really there are two reports: Daily Activity and Daily Activity Ch 9. Though 
	the Daily Activity report can be used successfully for both chapters, to see the 
	use of the UserID filter in Chapter 9, the Daily Activity CH 9 report should be 
	used.


*****************************************************************************************
* 	Restoring the Patient Referral Cube 						*
*****************************************************************************************

	1.) With the Hw_Analysis database restored (see above) right click the Patient 
	    Referral SSAS project and select "Process" to make sure it processes on your 
	    installation successfully.
	2.) Next, Right click the entire Patient Referral project in BIDs and click 
	    "Deploy" which will process and deploy the Patient Referral SSAS database to 
	    use with reports that use the Patient Referral cube in Chapter 12.


*****************************************************************************************
* 	Running the Code Samples 							*
*****************************************************************************************
	For specific details on setting up the code samples for Chapters 7, 8, 9 and 10 
	see the ReadMe.htm included in each chapter's folder. 


*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*

We sincerely hope that you enjoy the book as much as we enjoyed writing it! If 
you have any questions, concerns or comments, please feel free to write us.


Brian K. McDonald, MCDBA, MCSD, SQLBIGeek
Shawn McGehee
Rodney Landrum






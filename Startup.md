# Intro #
A simple application to help customize projects, list items, item types, item attachments, item history, and users. This is a simple application with simple UI. Easy to use desktop application. **Enjoy :)**

# Start Dev. #
**Install**
  * Install MS SQL 2008 or above
  * Install MS SQL Server Manager
  * Install .NET Framework

**Database**
  * Start MS SQL Server Managers and run the scripts in the following order
    * Run Script\_1\_CreateScrumMasterPlusPlus to created the database.
    * Run Script\_2\_CreateTablesAndStoredProcedures to created the Tables and SPs
    * Run Script\_3\_InsertStartUpItems to created the initial data. You can customize the content before running if you like to suit any of your needs.
  * Add the appropriate user. ( try not using sa for the the sake os security)

**.NET Code**
  * Configure the config file to connect to the database created
> > 

&lt;setting name="ConnectionString" serializeAs="String"&gt;


> > > 

&lt;value&gt;

Data Source=MyComputerName\SQLEXPRESS; Initial Catalog=ScrumQueue; User ID=MyUserName; Password=MyPassword;

&lt;/value&gt;



> > 

&lt;/setting&gt;


  * change MyComputerName, MyUserName, MyPassword
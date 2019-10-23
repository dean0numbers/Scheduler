# Scheduler
Contact Manager and Newsletter Scheduler

Date: July 21, 2019

Code base: C-Sharp, ASP, dot Net Framework.

This project was written with the intention of sending newleters about on going projects taking place with my Raspberry Pi 3B+ to various friends, and interested parties. Even though the design scope had just the Raspbeery Pi in mind, the project has the capabilty to schedule any document type and send it via email to the list of contacts managed by the contact manager. The current contact database has a limited scope, but the scope can be expanded as requied to meet your needs to include information such as demographics, etc. 

This project contains a Contact Manager a Newletter Scheduler. Both the Contact Manager and Scheduler rely on the dbNewsletter database currently served by SQL Server Express. As the project currently stands the schema for the database was programmed by hand, therefore, routines still must be written, that initialize the database schema for use. Database schema may be initialized manually using dbNewsLetter.sql

The initial goal was to get this up a running on Window, and then to migrate it over to the Raspberry Pi. I achieved to initial objective, but discovered that ASP dotNet Framework is only supported by msWindows and could not be migrated to Linux.

After discovering that I would need switch the project to the ASP dotNet Core framework, several security issues were never addressed, If you intend to use this on a production net-work I recommend that you address these. 

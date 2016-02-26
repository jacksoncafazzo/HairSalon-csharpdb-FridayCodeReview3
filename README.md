# Bab's Hair Salon
##### Epicodus csharp Friday Code Review Week 1

#### By Jackson Cafazzo


## Description

This program will allow Bab's Hair Salon to create a database of clients and which stylist they prefer.

## Setup

Clone repository from GitHub.
Navigate to directory.
In SQLCMD:
CREATE DATABASE hair_salon;
GO
USE hair_salon;
GO
CREATE TABLE stylists (id INT IDENTITY(1,1), name VARCHAR(255));
GO
CREATE TABLE clients (id INT IDENTITY(1,1), name VARCHAR(255), stylist_id INT);
GO

In Command Line:
run "dnu restore"
run "dnx test" to see if tests are passing and database is functioning correctly.
run "dnx kestrel"
Navigate to http://localhost:5004

## Technologies Used

csharp, MSSQL, Nancy, Razor, HTML5, CSS3, Bootstrap

### Legal

Copyright (c) 2/26/2016, Jackson Cafazzo

This software is licensed under the MIT license.

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

# Supermarket Management Application

## Overview
This application is designed to manage a supermarket system, created using C#, WPF framework, and SQLServer for the database. It adheres to the MVVM model structure.

## Features
- **Product Management**: Handle products with details like name, barcode, category, and manufacturer.
- **Manufacturer Information**: Track manufacturers and their country of origin.
- **Category Management**: Manage various product categories. Additionally, administrators can track the total value associated with each category.
- **Stock Management**: Monitor stock levels, supply and expiry dates, purchase and selling prices.
- **User Management**: Manage user accounts including username, password, and user type. Additionally, administrators can track the total value of receipts associated with every employee.
- **Receipts Management**: Generate and manage sales receipts with detailed product lists, quantities, subtotals, and total amounts collected.
- **Inactive Data Handling**: Data is never physically deleted but marked as inactive for logical deletion.

## Technical Details
- **Database Normalization**: The database is normalized to the third normal form to ensure data integrity.
- **Stored Procedures**: Stored procedures are implemented for insert, update, and select operations.
- **Layered Architecture**: The application is structured in layers for separation of concerns.
- **Security**: SQL injection prevention is implemented in parameterized queries.
- **MVVM and Data Binding**: The application is structured on the MVVM pattern and uses Data Binding.

## User Roles
- **Administrator**: Can add, modify, view, and logically delete users, categories, manufacturers, products, stocks, etc. They can also perform various data searches and view reports.
- **Cashier**: Responsible for product searches and issuing sales receipts.

## Validation and Price Calculation
- Fields in forms for adding, modifying, and deleting are validated. The selling price is automatically calculated based on a formula (purchase price + commercial markup) which is stored in a configuration file.

## Reporting
- Administrators can generate reports based on manufacturer, category value, daily collections by users, and details of the largest receipt of the day.

## Installation
1. Clone the repository
2. Restore the database using Supermarket.bak
3. Change the connection string in DALHelper

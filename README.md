# ExpensesAPI .NET Web API Application with a REST-API 
[<img src="https://run.pstmn.io/button.svg" alt="Run In Postman" style="width: 128px; height: 32px;">](https://god.gw.postman.com/run-collection/36631489-97526e27-e1db-4069-9ab6-9a7b22befd95?action=collection%2Ffork&source=rip_markdown&collection-url=entityId%3D36631489-97526e27-e1db-4069-9ab6-9a7b22befd95%26entityType%3Dcollection%26workspaceId%3Ddfd66c26-965e-4ef8-ba5d-9ab9d0f981eb)

This project is a .NET Web API application. It allows users to create and list expenses, ensuring that some validation rules are applied. I am using SQL Server Database to persist datas.

## Project Description

The ExpensesAPI project provides a REST API to:

- Create expenses
- List expenses

### Resources

- **Expenses**: An expense is characterized by a user, date, type (Restaurant, Hotel, Misc), amount, currency, and a comment.
- **Users**: A user is characterized by a last name, first name, and a default currency for their expenses.

### Main Features

1. **Creating an Expense**: 
   - An expense cannot have a date in the future.
   - An expense cannot be dated more than 3 months ago.
   - The comment is mandatory.
   - A user cannot declare the same expense twice (same date and amount).
   - The currency of the expense must match the user’s currency.

2. **Listing Expenses**
3. **Creating Users**
4. **Listing Users**

## Technologies Used

- .NET Core
- Entity Framework Core
- SQL Server
- Swagger for API documentation
- Moq and xUnit for unit testing

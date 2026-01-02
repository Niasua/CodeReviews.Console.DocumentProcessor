# Document Processor

This is a Console Application built with **.NET 8** that automates the process of extracting contact data from multiple file formats, loading it into a SQL Server database, and generating PDF reports.

## Key Features

* **Multi-Format Extraction:** Capable of parsing data from both `.csv` and `.xlsx` files seamlessly.
* **Polymorphic Design:** Implements the **Factory Pattern** to dynamically select the correct parser based on file extension.
* **Idempotent Data Loading:** Includes a "Bulk Check" mechanism to prevent duplicate entries in the database, optimizing performance by minimizing SQL queries.
* **PDF Reporting:** Generates a clean, tabular PDF report using a code-first approach for document layout.
* **Secure Configuration:** Uses **User Secrets** to manage sensitive connection strings, keeping them out of the source code.

## ⚙️ Getting Started

### Prerequisites
* .NET 8 SDK
* SQL Server (or LocalDB)

### Installation

1.  **Clone the repository**
    ```bash
    git clone [https://github.com/Niasua/CodeReviews.Console.DocumentProcessor](https://github.com/Niasua/CodeReviews.Console.DocumentProcessor)
    cd DocumentProcessor
    ```

2.  **Configure Database Connection**
    This project uses User Secrets. Run the following command in the project directory to set your connection string:
    ```bash
    dotnet user-secrets init
    dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Server=(localdb)\\MSSQLLocalDB;Database=PhoneBookDb;Trusted_Connection=True;"
    ```

3.  **Apply Migrations**
    Create the database and apply the schema:
    ```bash
    dotnet ef database update
    ```

4.  **Run the Application**
    Ensure you have a source file (e.g., `contacts.csv`) in the project root or build directory.
    ```bash
    dotnet run
    ```
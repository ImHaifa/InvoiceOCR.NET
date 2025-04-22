# InvoiceOCR.NET 🔍

An ASP.NET 9 MVC web application that allows users to upload invoice files (PDFs or images), extracts text using Tesseract OCR, and stores extracted text in a SQL Server database.

## 🛠 Tech Stack

- .NET 9.0 MVC
- C#
- Entity Framework Core
- SQL Server
- Tesseract OCR (with Arabic + English language support)
- Bootstrap 5 (for UI)

---

## 🚀 Features

- Upload invoice images (JPG, PNG, PDF)
- OCR extraction using [Tesseract](https://github.com/tesseract-ocr/tesseract.git)
- Multilingual support (Arabic + English)
- Save extracted data to a SQL Server database
- View list of invoices in a dashboard
- Soon: Power Automate integration (for workflow automation)

---

## 📦 Setup Instructions

### 1. Clone the Repository
```bash
git clone https://github.com/yourusername/invoice-ocr-mvc.git
cd invoice-ocr-mvc
```

### 2. Import DB using Script.sql in SQL Server


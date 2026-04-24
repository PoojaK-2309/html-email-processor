# HTML Email Processor (.NET)

A memory-efficient .NET console application for processing large volumes of HTML email data without running into OutOfMemory exceptions.

## 🚀 Features

- Streaming JSON processing using `IAsyncEnumerable`
- Avoids loading entire dataset into memory
- HTML content extraction and cleaning
- Thread-safe file writing
- Structured logging
- Scalable design for large datasets

## 🛠 Tech Stack

- .NET 8
- System.Text.Json
- Async Streams (`IAsyncEnumerable`)
- HtmlAgilityPack (optional if extended)

## 📂 Project Structure
Models/ -> Email data models
Services/ -> API + Processing logic
Utilities/ -> Logging + HTML cleaning
Program.cs -> Entry point
sample-emails.json -> Sample data

## ▶️ How to Run

1. Open in Visual Studio
2. Build solution
3. Run the project

## 📈 Output

- Console logs
- `output.txt` file generated in `/bin/Debug/net8.0/`
- 
## 📸 Screenshots

### 🔹 Streaming Logic (Memory Efficient Processing)
![Streaming](assets/streaming-logic.png)

### 🔹 Project Architecture
![Structure](assets/project-structure.png)

### 🔹 Console Output
![Console](assets/console-output.png)

### 🔹 Processed Output File
![Output](assets/output-file.png)

## 💡 Problem Solved

Efficiently processes large HTML email datasets without causing memory overflow by using streaming instead of full deserialization.

---

## 📬 Author

.NET Backend Developer | API Development | Performance Optimization

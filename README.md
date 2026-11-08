# 🏥 HIS — Hospital Information System

A large, multi-module **Hospital Information System** built as a graduation project with **C# WinForms**, **SQL Server** and **RDLC reports**. It covers the financial and operational side of a hospital: patient billing, insurance and contracting entities, claims, procurement and inventory.

![C#](https://img.shields.io/badge/C%23-512BD4?style=flat-square&logo=dotnet&logoColor=white)
![.NET Framework](https://img.shields.io/badge/.NET%20Framework-WinForms-5C2D91?style=flat-square&logo=dotnet&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQL%20Server-CC2927?style=flat-square&logo=microsoftsqlserver&logoColor=white)
![RDLC Reports](https://img.shields.io/badge/RDLC-Reports-0078D4?style=flat-square&logo=microsoft&logoColor=white)

## 🧩 Modules

| Module | Highlights |
|---|---|
| **Setup & pricing** | Regions, contracting entities and their branches, entity categories, patient categories, accommodation degrees & pricing, service pricing, regulation prices, operation skills |
| **Patient billing** | Patient visits, visit bills, medicine / residence / service items, cash payments and refunds |
| **Insurance claims** | Inpatient, outpatient and medicine claims, claims delivery, claims payment, claim cancellation, debit / credit notices |
| **Procurement** | Suppliers, price quotations, bid-evaluation committee minutes, purchase memos, supply orders for medicines, items, assets and services, supplier payment forms |
| **Inventory** | Stores, item categories and items, departments, stock notifications for medicines, supplies, assets and maintenance |
| **Administration** | Users and permissions, main dashboard |

## 📊 Reporting

Dozens of printable **RDLC** reports backed by typed DataSets (banks, clients, bills, claims, supply orders…).

## 🧱 Structure

```
All modules/
├── HIS.sln
└── HIS/            # WinForms screens, typed DataSets (.xsd) and RDLC reports
```

## 🚀 Getting started

1. Open `All modules/HIS.sln` in Visual Studio.
2. Restore the HIS database on SQL Server and update the connection string.
3. Build and run (F5).

---
👤 **Ahmed Hamam** · [LinkedIn](https://www.linkedin.com/in/ahmedhamam50/) · [Portfolio](https://ahmedhamam.github.io)

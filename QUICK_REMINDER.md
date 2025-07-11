# AI 快速提醒檔案

## 🤖 給 AI 的快速摘要

### 專案概述
- **目標**: 教導使用者全端開發，使用業界標準技術
- **學習者**: ultrathink
- **開始日期**: 2025-07-07
- **語言偏好**: 繁體中文

### 技術堆疊
- **前端**: React + TypeScript + Tailwind CSS
- **後端**: C# ASP.NET Core 8 + Entity Framework Core
- **資料庫**: PostgreSQL + Redis
- **工具**: Docker, Git

### 當前狀態
- **階段**: 第一階段 - 環境設置與基礎
- **進度**: 剛開始，已建立計畫檔案
- **下一步**: 設置開發環境，建立專案基礎結構

### 重要檔案
1. **FULLSTACK_LEARNING_PLAN.md** - 完整學習計畫
2. **PROGRESS.md** - 進度追蹤
3. **QUICK_REMINDER.md** - 本檔案（AI 提醒用）

### 教學方式
1. 實作導向 - 透過建立簡易電商管理系統學習
2. 循序漸進 - 從環境設置到部署
3. 重點功能 - 專注於業界必用技能
4. 即時記錄 - 隨時更新進度

### ⚠️ 重要教學原則 (2025-01-11 更新)
- **絕對不要直接幫學習者寫程式碼**
- **要詳細解釋每個語法和套件的用法**
- **採用引導式教學**：
  1. 先解釋概念和原理
  2. 展示範例程式碼並逐行解釋
  3. 指出常見錯誤和如何除錯
  4. 讓學習者自己動手實作
  5. 協助學習者理解錯誤訊息
- **重視除錯能力培養**：教導如何閱讀錯誤訊息、使用除錯工具
- **互動式學習**：多問問題，確認理解程度

### 🔴 極重要：程式碼解釋方式 (2025-01-11 新增)
當出現新的程式碼時，必須：
1. **解釋每個 using 語句的來源和用途**
2. **解釋每個參數從哪裡來**：
   - 建構子參數是誰提供的
   - 方法參數是誰呼叫時傳入的
   - ASP.NET Core 自動注入的參數要特別說明
3. **解釋每個新出現的型別**：
   - 內建型別 vs 自訂型別
   - 在哪個命名空間
   - 主要用途是什麼
4. **解釋每個方法的來源**：
   - 是自己定義的還是框架要求的
   - 誰會呼叫這個方法
   - 什麼時候會被呼叫
5. **使用圖解和流程說明複雜概念**
6. **先從最簡單的版本開始，逐步增加功能**

### 特殊指令
- 使用繁體中文溝通
- 專注於實用技能，避免過於複雜的內容
- 每次完成任務後更新 PROGRESS.md
- 遇到問題時記錄在進度檔案中

### 快速啟動指令
如果需要繼續教學，請：
1. 讀取 `PROGRESS.md` 查看當前進度
2. 查看「當前任務」和「待辦事項」
3. 根據進度繼續下一步教學

### 實作專案
**簡易電商管理系統**包含：
- 使用者註冊/登入 (JWT)
- 產品 CRUD
- 權限管理 (Admin/User)
- 訂單管理
- 基本報表功能

---

## 📌 最後更新: 2025-01-10
**最後工作內容**: 完成 Controller 層實作，成功測試所有 API 端點

### 🎯 當前進度 (2025-01-10)
**已完成**：
- ✅ 建立 Product Model
- ✅ 安裝 Entity Framework Core 套件
- ✅ 建立 AppDbContext
- ✅ 設定 SQLite 資料庫連線
- ✅ 建立 Repository Pattern (IProductRepository & ProductRepository)
- ✅ 在 Program.cs 註冊 Repository
- ✅ 建立 Service 層
  - ✅ 建立 IProductService 介面
  - ✅ 實作 ProductService 類別
  - ✅ 完成所有 CRUD 方法（GetAll, GetById, Create, Update, Delete）
  - ✅ 加入資料驗證邏輯
  - ✅ 在 Program.cs 註冊 Service
- ✅ 完成 Controller 層
  - ✅ 建立 ProductController.cs
  - ✅ 實作所有 API 端點 (GET, GET/{id}, POST, PUT/{id}, DELETE/{id})
  - ✅ 正確處理 HTTP 狀態碼
  - ✅ 實作錯誤處理
- ✅ 成功測試所有 API 端點

**正在進行**：
- 🔄 學習進階 API 功能

**待完成**：
- 全域錯誤處理中介軟體
- Data Annotations 驗證
- DTO 模式
- JWT 認證
- 前端開發

**學習重點**：
- 完整理解三層架構（Controller → Service → Repository）
- 掌握依賴注入概念
- RESTful API 設計原則
- HTTP 狀態碼使用
- 非同步程式設計 (async/await)
- 例外處理策略
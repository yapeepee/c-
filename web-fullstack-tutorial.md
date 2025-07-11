# 全端網頁開發教學計畫 - C#, TypeScript, SQL

## 專案概述
建立一個簡單的待辦事項（Todo List）網頁應用程式，包含完整的前後端架構。

## 技術堆疊
- **後端**: C# (.NET 8 Web API)
- **前端**: TypeScript + HTML + CSS (原生，不使用框架)
- **資料庫**: SQL Server 或 SQLite
- **工具**: Visual Studio Code, .NET CLI, Node.js

## 專案結構
```
TodoApp/
├── Backend/
│   ├── TodoApi/
│   │   ├── Controllers/
│   │   ├── Models/
│   │   ├── Data/
│   │   ├── Program.cs
│   │   └── appsettings.json
│   └── TodoApi.sln
├── Frontend/
│   ├── src/
│   │   ├── index.html
│   │   ├── styles.css
│   │   ├── app.ts
│   │   └── api.ts
│   ├── dist/
│   ├── package.json
│   └── tsconfig.json
└── Database/
    └── create_tables.sql
```

## 學習步驟

### 第一步：環境設定
1. 安裝必要軟體
   - .NET 8 SDK
   - Node.js 和 npm
   - SQL Server Express 或使用 SQLite
   - Visual Studio Code

2. 安裝開發工具
   ```bash
   # 安裝 TypeScript
   npm install -g typescript
   
   # 確認 .NET 安裝
   dotnet --version
   ```

### 第二步：建立資料庫
1. 設計資料表結構
   - Todo 表格：Id, Title, Description, IsCompleted, CreatedAt, UpdatedAt

2. 撰寫 SQL 建表語句（SQLite 版本）
   ```sql
   -- 建立 Todo 資料表
   CREATE TABLE IF NOT EXISTS Todos (
       Id INTEGER PRIMARY KEY AUTOINCREMENT,  -- 自動遞增的主鍵
       Title NVARCHAR(200) NOT NULL,          -- 必填的標題
       Description NVARCHAR(500),             -- 選填的描述
       IsCompleted BOOLEAN DEFAULT 0,         -- 預設為未完成
       CreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP,  -- 自動記錄建立時間
       UpdatedAt DATETIME                     -- 更新時間（由觸發器管理）
   );
   
   -- 建立自動更新時間戳記的觸發器
   CREATE TRIGGER update_todo_timestamp 
   AFTER UPDATE ON Todos
   FOR EACH ROW
   BEGIN
       UPDATE Todos SET UpdatedAt = CURRENT_TIMESTAMP WHERE Id = NEW.Id;
   END;
   ```

### 第三步：建立後端 API
1. 建立 .NET Web API 專案
   ```bash
   dotnet new webapi -n TodoApi
   dotnet new sln -n TodoApi
   dotnet sln add TodoApi
   ```

2. 建立資料模型 (Model)
   - Todo.cs：定義 Todo 實體類別
   - TodoDto.cs：定義資料傳輸物件

3. 設定資料庫連線
   - 安裝 Entity Framework Core
   - 建立 DbContext
   - 設定連線字串

4. 建立 API 控制器
   - GET /api/todos - 取得所有待辦事項
   - GET /api/todos/{id} - 取得單一待辦事項
   - POST /api/todos - 新增待辦事項
   - PUT /api/todos/{id} - 更新待辦事項
   - DELETE /api/todos/{id} - 刪除待辦事項

5. 設定 CORS
   - 允許前端網頁存取 API

### 第四步：建立前端介面
1. 設定 TypeScript 專案
   ```bash
   npm init -y
   npm install --save-dev typescript
   npx tsc --init
   ```

2. 建立 HTML 結構
   - 標題區
   - 新增待辦事項表單
   - 待辦事項列表
   - 操作按鈕

3. 撰寫 CSS 樣式
   - 基本版面配置
   - 表單樣式
   - 列表樣式
   - 響應式設計

4. 實作 TypeScript 功能
   - 定義介面和型別
   - API 呼叫函式
   - DOM 操作
   - 事件處理

### 第五步：整合前後端
1. 設定 API 端點
2. 實作 AJAX 請求
3. 處理非同步操作
4. 錯誤處理

### 第六步：測試與除錯
1. 測試 API 端點
   - 使用 Postman 或 curl
   - 檢查回應格式

2. 測試前端功能
   - 新增待辦事項
   - 顯示列表
   - 更新狀態
   - 刪除項目

3. 除錯技巧
   - 使用瀏覽器開發者工具
   - 檢查網路請求
   - Console.log 除錯

### 第七步：部署準備
1. 建置前端
   ```bash
   tsc
   ```

2. 發布後端
   ```bash
   dotnet publish -c Release
   ```

3. 資料庫遷移

## 學習重點

### C# 重點
- RESTful API 設計
- 依賴注入 (DI)
- Entity Framework Core
- 非同步程式設計 (async/await)
- LINQ 查詢

### TypeScript 重點
- 型別系統
- 介面定義
- 類別與模組
- Promise 與 async/await
- DOM 操作與型別

### SQL 重點
- 基本 CRUD 操作
- 主鍵與索引
- 資料型別選擇
- 基本查詢優化

## 進階擴充建議
1. 加入使用者認證
2. 實作分頁功能
3. 加入搜尋功能
4. 資料驗證
5. 單元測試

## 學習資源
- [Microsoft Learn - ASP.NET Core](https://learn.microsoft.com/zh-tw/aspnet/core/)
- [TypeScript 官方文件](https://www.typescriptlang.org/docs/)
- [MDN Web Docs](https://developer.mozilla.org/zh-TW/)
- [Entity Framework Core 文件](https://learn.microsoft.com/zh-tw/ef/core/)

## 注意事項
- 每完成一個步驟都要測試
- 保持程式碼簡潔易懂
- 遵循命名規範
- 適當加入註解
- 使用版本控制 (Git)
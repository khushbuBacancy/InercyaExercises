--Question 1 : Get the list of not discontinued products including category name ordered by product name

SELECT p.ProductID, P.ProductName, P.CategoryID, C.CategoryName
FROM dbo.Products P
JOIN dbo.Categories C ON P.CategoryID = C.CategoryID
WHERE Discontinued = 0
ORDER BY P.ProductName ASC
---------------------------------------------------------------------------------------------
--Question 2 : Get all Nancy Davolio’s customers.


SELECT C.CustomerID, C.ContactName Customer
FROM Customers C
JOIN Orders O ON C.CustomerID = O.CustomerID
JOIN Employees E ON O.EmployeeID = E.EmployeeID
WHERE E.FirstName = 'Nancy' AND E.LastName = 'Davolio';



---------------------------------------------------------------------------------------------
--Question 3 : Get the total ordered amount (money) by year of the employee Steven Buchanan.


SELECT YEAR(O.OrderDate) AS OrderYear, SUM(OD.Quantity * OD.UnitPrice) AS TotalOrderedAmount
FROM Orders O
JOIN [Order Details] OD ON O.OrderID = OD.OrderID
JOIN Employees E ON O.EmployeeID = E.EmployeeID
WHERE E.FirstName = 'Steven' AND E.LastName = 'Buchanan'
GROUP BY YEAR(O.OrderDate);



---------------------------------------------------------------------------------------------
--Question 4 : Get the name of all employees that directly or indirectly report to Andrew Fuller

;WITH EmployeeReportsToCTE AS
(
	SELECT EmployeeID, TitleOfCourtesy, FirstName,LastName, ReportsTo
    FROM Employees
    WHERE ReportsTo = (SELECT EmployeeID FROM Employees WHERE FirstName = 'Andrew' AND LastName = 'Fuller')

	UNION ALL

	SELECT E.EmployeeID, E.TitleOfCourtesy, E.FirstName, E.LastName, E.ReportsTo
    FROM Employees E
    INNER JOIN EmployeeReportsToCTE ER ON e.ReportsTo = ER.EmployeeID
)

SELECT TitleOfCourtesy + ' ' + FirstName + ' ' +  LastName Employee
FROM EmployeeReportsToCTE;

---------------------------------------------------------------------------------------------








---------------------------------------------------------------------------------------------
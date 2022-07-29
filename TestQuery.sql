SELECT rv.Name, b.Title, rs.Rating, rs.Rating_Date
FROM 
ratings rs
INNER JOIN 
books b
ON rs.Book_Id=b.Id
INNER JOIN 
reviewers rv
ON rs.Reviewer_Id = rv.Id
order by rv.Name,b.Title, rs.Rating;
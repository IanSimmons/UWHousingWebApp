Declare @StudentID As BigInt = 9071111116

SELECT Firstname, Lastname, Paymentenclosed As PaymentAmount, Paymentdate FROM student AS A INNER JOIN payment AS B On A.StudentID = B.StudentID
                                Where A.StudentID = @StudentID
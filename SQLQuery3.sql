 SELECT p.Id, p.Name, p.ImageUrl,
                         up.FirebaseUserId, up.Email
                        
                        FROM Pattern p
                        JOIN UserProfile up ON p.UserId = up.Id
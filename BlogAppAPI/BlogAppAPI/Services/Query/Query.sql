select * from Users

select * from Roles


select * from UserRoles

select * from RoleClaims

select * from Category
select * from Post

select * from PostCategories

select * from Author

select * from Tag


delete Category where CategoryId>15

insert into Category values ('MOBILE','mobile','lap-trinh-mobile')
insert into Category values ('desktop','desktop','lap-trinh-desktop')
insert into Category values ('iot','iot','lap-trinh-iot')
insert into Category values ('http','http','lap-trinh-http')
insert into Category values ('websocket','websocket','lap-trinh-websocket')
insert into Category values ('socket','socket','lap-trinh-socket')
insert into Category values ('tcp','tcp','lap-trinh-tcp')

insert into UserRoles(UserId,RoleId) values ('06e33444-a93a-4008-9bc1-68eba918ad2b','ADMIN')
insert into UserRoles(UserId,RoleId) values ('06e33444-a93a-4008-9bc1-68eba918ad2b','MOD')
insert into UserRoles(UserId,RoleId) values ('06e33444-a93a-4008-9bc1-68eba918ad2b','USER')


insert into Post(PostTitle,PostDescription,PostContent,PostSlug,AuthorId,CreateDate,UpdateDate)  values('title','des','content','slug-post',7,GETDATE(),GETDATE())



insert into PostCategories(PostId,CategoryId) values(2,1)
insert into PostCategories(PostId,CategoryId) values(3,1)
insert into PostCategories(PostId,CategoryId) values(7,1)
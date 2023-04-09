CREATE TABLE "User" (
  "id_user" int PRIMARY KEY,
  "login" string UNIQUE,
  "pass" string
);

CREATE TABLE "Post" (
  "owner" int,
  "id_post" int PRIMARY KEY,
  "photo_for_owner" file,
  "photo_for_other" file,
  "subscript" string
);

ALTER TABLE "Post" ADD FOREIGN KEY ("owner") REFERENCES "User" ("id_user");

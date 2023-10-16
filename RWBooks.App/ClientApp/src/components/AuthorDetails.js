import React, { useState } from "react";
import { Link } from "react-router-dom";

const AuthorDetails = () => {
  const author = { id: "1", name: "Author 1" };

  const [books] = useState([
    { id: "1", title: "Book 1" },
    { id: "2", title: "Book 2" },
    { id: "3", title: "Book 3" },
  ]);

  return (
    <div className="container mt-5">
      <h1>{author.name}</h1>
      <div className="d-flex flex-wrap">
        {books.map((book) => (
          <div
            key={book.id}
            className="card m-2"
            style={{ width: "12rem", height: "18rem" }}
          >
            <div className="card-body">
              <h5 className="card-title">{book.title}</h5>
              <Link to={`/books/${book.id}`} className="btn btn-primary">
                View Details
              </Link>
            </div>
          </div>
        ))}
      </div>
    </div>
  );
};

export default AuthorDetails;

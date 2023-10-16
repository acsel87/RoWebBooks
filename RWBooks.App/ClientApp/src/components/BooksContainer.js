// src/components/BooksContainer.js
import React, { useState } from "react";
import { Link } from "react-router-dom";

const BooksContainer = () => {
  // Fake data
  const [books] = useState([
    { id: "1", title: "Book 1" },
    { id: "2", title: "Book 2" },
    { id: "3", title: "Book 3" },
    { id: "4", title: "Book 4" },
    { id: "5", title: "Book 5" },
    { id: "6", title: "Book 6" },
    { id: "7", title: "Book 7" },
    { id: "8", title: "Book 8" },
    { id: "9", title: "Book 9" },
    { id: "10", title: "Book 10" },
  ]);

  return (
    <div className="container mt-5">
      <div className="d-flex justify-content-end mb-3">
        <Link to="/add-book" className="btn btn-primary">
          Add Book
        </Link>
      </div>
      <div className="row" style={{ overflowY: "auto", maxHeight: "600px" }}>
        {books.map((book) => (
          <div key={book.id} className="col-md-3 mb-4">
            <div className="card-body" style={{ padding: 0 }}>
              <div
                style={{
                  backgroundColor: "#f0f0f0",
                  height: "240px",
                  width: "170px",
                  display: "flex",
                  alignItems: "center",
                  justifyContent: "center",
                  margin: "auto",
                }}
              >
                <span>{book.title}</span>
              </div>
              <p className="card-text text-center mt-2">{book.id}</p>
            </div>
          </div>
        ))}
      </div>
    </div>
  );
};

export default BooksContainer;

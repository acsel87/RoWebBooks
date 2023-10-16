// src/components/Home.js
import React from "react";
import { Link } from "react-router-dom";

const Home = () => {
  return (
    <div className="row mt-5">
      <div className="col-md-6">
        <div className="card text-center">
          <div className="card-body">
            <h5 className="card-title">Authors</h5>
            <p className="card-text">View the list of authors</p>
            <Link to="/authors" className="btn btn-primary">
              Go to Authors
            </Link>
          </div>
        </div>
      </div>
      <div className="col-md-6">
        <div className="card text-center">
          <div className="card-body">
            <h5 className="card-title">Books</h5>
            <p className="card-text">View the list of books</p>
            <Link to="/books" className="btn btn-primary">
              Go to Books
            </Link>
          </div>
        </div>
      </div>
    </div>
  );
};

export default Home;

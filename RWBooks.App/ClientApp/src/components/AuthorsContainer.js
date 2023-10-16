import React, { useState, useEffect } from "react";
import { Button } from "react-bootstrap";
import AddAuthorModal from "./AddAuthorModal";

const AuthorsContainer = () => {
  const [authors, setAuthors] = useState([]);
  const [loading, setLoading] = useState(true);
  const [showModal, setShowModal] = useState(false);

  const fetchAuthors = async () => {
    try {
      const response = await fetch("authors");
      if (!response.ok) {
        throw new Error("Network response was not ok " + response.statusText);
      }
      const data = await response.json();
      setAuthors(data.data.authorListItems);
      setLoading(false);
    } catch (error) {
      console.error(
        "There has been a problem with your fetch operation:",
        error
      );
    }
  };

  useEffect(() => {
    fetchAuthors();
  }, []);

  const handleShow = () => setShowModal(true);
  const handleClose = () => setShowModal(false);

  return (
    <div className="container mt-5">
      <div className="d-flex justify-content-end mb-3">
        <Button variant="primary" onClick={handleShow}>
          Add Author
        </Button>
      </div>
      <div className="row" style={{ overflowY: "auto", maxHeight: "600px" }}>
        {loading ? (
          <div>Loading...</div>
        ) : (
          authors.map((author) => (
            <div key={author.id} className="col-md-3 mb-4">
              <div
                className="card"
                style={{
                  height: "200px",
                  width: "150px",
                  display: "flex",
                  alignItems: "center",
                  justifyContent: "center",
                  margin: "auto",
                }}
              >
                <div className="card-body">
                  <h5 className="card-title">{author.name}</h5>
                </div>
              </div>
            </div>
          ))
        )}
      </div>
      <AddAuthorModal
        show={showModal}
        handleClose={handleClose}
        refreshAuthors={fetchAuthors}
      />
    </div>
  );
};

export default AuthorsContainer;

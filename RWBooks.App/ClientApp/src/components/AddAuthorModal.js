import React, { useState } from "react";
import { Modal, Button, Form } from "react-bootstrap";

const AddAuthorModal = ({ show, handleClose, refreshAuthors }) => {
  const [authorName, setAuthorName] = useState("");
  const [bookName, setBookName] = useState("");
  const [books, setBooks] = useState([]);

  const addBook = () => {
    setBooks([...books, { name: bookName }]);
    setBookName("");
  };

  const saveAuthor = async () => {
    const author = {
      name: authorName,
      // books
    };
    try {
      const response = await fetch("authors/Create", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(author),
      });
      if (!response.ok) {
        throw new Error("Network response was not ok " + response.statusText);
      }
      handleClose();
      refreshAuthors(); // Refresh the list of authors after the new author is created
    } catch (error) {
      console.error(
        "There has been a problem with your fetch operation:",
        error
      );
    }
  };

  return (
    <Modal show={show} onHide={handleClose}>
      <Modal.Header closeButton>
        <Modal.Title>Add Author</Modal.Title>
      </Modal.Header>
      <Modal.Body>
        <Form>
          <Form.Group controlId="authorName">
            <Form.Label>Author Name</Form.Label>
            <Form.Control
              type="text"
              placeholder="Enter author name"
              value={authorName}
              onChange={(e) => setAuthorName(e.target.value)}
            />
          </Form.Group>
          <Form.Group controlId="bookName">
            <Form.Label>Add Books</Form.Label>
            <div className="d-flex">
              <Form.Control
                type="text"
                placeholder="Enter book name"
                value={bookName}
                onChange={(e) => setBookName(e.target.value)}
              />
              <Button variant="primary" onClick={addBook}>
                +
              </Button>
            </div>
          </Form.Group>
          <div>
            {books.map((book, index) => (
              <div key={index}>{book.name}</div>
            ))}
          </div>
        </Form>
      </Modal.Body>
      <Modal.Footer>
        <Button variant="secondary" onClick={handleClose}>
          Close
        </Button>
        <Button variant="primary" onClick={saveAuthor}>
          Save Author
        </Button>
      </Modal.Footer>
    </Modal>
  );
};

export default AddAuthorModal;

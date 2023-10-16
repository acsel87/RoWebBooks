import React, { useState, useEffect } from "react";

export function AuthorsContainer() {
  const [authors, setAuthors] = useState([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    const populateAuthors = async () => {
      const response = await fetch("authors");
      const data = await response.json();
      setAuthors(data);
      setLoading(false);
    };

    populateAuthors();
  }, []);

  const renderAuthorsPages = (authors) => (
    <table className="table table-striped" aria-labelledby="tableLabel">
      <thead>
        <tr>
          <th>Name</th>
        </tr>
      </thead>
      <tbody>
        {authors.map((author) => (
          <tr key={author.name}>
            <td>{author.name}</td>
          </tr>
        ))}
      </tbody>
    </table>
  );

  const contents = loading ? (
    <p>
      <em>Loading...</em>
    </p>
  ) : (
    renderAuthorsPages(authors)
  );

  return (
    <div>
      <h1 id="tableLabel">Authors</h1>
      {contents}
    </div>
  );
}

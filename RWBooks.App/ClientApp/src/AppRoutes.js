import AuthorsContainer from "./components/AuthorsContainer";
import BooksContainer from "./components/BooksContainer";
import Home from "./components/Home";
import AuthorDetails from "./components/AuthorDetails";

const AppRoutes = [
  {
    index: true,
    element: <Home />,
  },
  {
    path: "/authors",
    element: <AuthorsContainer />,
  },
  {
    path: "/books",
    element: <BooksContainer />,
  },
  {
    path: "/authors/:authorId",
    element: <AuthorDetails />,
  },
];

export default AppRoutes;

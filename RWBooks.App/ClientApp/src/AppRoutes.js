import { AuthorsContainer } from "./components/AuthorsContainer";
import { Home } from "./components/Home";

const AppRoutes = [
  {
    index: true,
    element: <Home />
  },  
  {
    path: '/authors',
    element: <AuthorsContainer />
  }
];

export default AppRoutes;

import { CssBaseline, Container, Box } from "@mui/material"
import NavBar from "./NavBar";
import { Outlet, useLocation } from "react-router";
import Homepage from "../../features/activities/home/Homepage";

function App() {
  const location = useLocation();

  return (
    <Box sx={{bgcolor: '#eeeeee', minHeight: '100vh'}}>
      <CssBaseline />
      {location.pathname === '/' ? <Homepage /> : (
        <>
          <NavBar />
          <Container maxWidth='xl' sx={{mt: 3}}>
            <Outlet />
          </Container>
        </>
      )}
    </Box>
  )
}

export default App

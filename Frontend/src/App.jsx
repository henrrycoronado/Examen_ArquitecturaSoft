import React from "react";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import HistorialTransaccion from "./pages/HistorialTransaccion";

const App = () => {
  return (
      <Router>
          <Routes>
            <Route path="/" element={<HistorialTransaccion />}/>
          </Routes>
      </Router>
  );
};

export default App;
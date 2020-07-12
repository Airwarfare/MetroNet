import React, { useState } from "react";
import "./App.css";
import { createMuiTheme, ThemeProvider } from "@material-ui/core/styles";
import { CssBaseline, Card, CardContent } from "@material-ui/core";
import IntroductionForm from "./Components/IntroductionForm";
import { BrowserRouter as Router, Switch, Route } from "react-router-dom";
import IntroductionBox from "./Components/IntroductionBox";

const theme = createMuiTheme({
  palette: {
    type: "dark",
  },
});

function App() {
  const [member, setMember] = useState({
    name: "Sample",
    funFact: "Sample Sample Sample Sample Sample Sample Sample",
  });

  const onSubmit = (member) => {
    setMember(member);
  };

  return (
    <ThemeProvider theme={theme}>
      <Router>
        <CssBaseline />
        <div
          style={{
            height: "100%",
            width: "100%",
            display: "flex",
            justifyContent: "center",
            alignItems: "center",
          }}
        >
          <Switch>
            <Route exact path="/">
              <Card style={{ width: 250, display: "block" }}>
                <CardContent style={{ paddingBottom: 16 }}>
                  <IntroductionForm onSubmit={onSubmit} />
                </CardContent>
              </Card>
            </Route>

            <Route exact path="/introduction">
              <Card style={{ width: 250, display: "block" }}>
                <CardContent style={{ paddingBottom: 16 }}>
                  <IntroductionBox {...member} />
                </CardContent>
              </Card>
            </Route>
          </Switch>
        </div>
      </Router>
    </ThemeProvider>
  );
}

export default App;

import React from "react";
import { Typography, Button, Divider } from "@material-ui/core";
import { useHistory } from "react-router-dom";

export default function IntroductionBox(props) {
  const history = useHistory();

  return (
    <>
      <Typography>Name: {props.name}</Typography>
      <Divider />
      <Typography>Fun Fact: {props.funFact}</Typography>
      <Divider />
      <Button
        color="primary"
        variant="contained"
        style={{ width: "100%", marginTop: 5 }}
        onClick={() => history.push("/")}
      >
        Introduce Again
      </Button>
    </>
  );
}

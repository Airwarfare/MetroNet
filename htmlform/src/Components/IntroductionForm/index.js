import React, { useState } from "react";
import { TextField, Button } from "@material-ui/core";
import { useHistory } from "react-router-dom";

const commonProps = {
  InputLabelProps: {
    shrink: true,
  },
  variant: "outlined",
  size: "small",
  style: {
    marginBottom: 10,
  },
};

export default function IntroductionForm(props) {
  const history = useHistory();
  const [name, setName] = useState("");
  const [funFact, setFunFact] = useState("");
  const [error, setError] = useState(false);

  const onSubmit = () => {
    if (name === "" || funFact === "") {
      setError(true);
      alert(
        "There was a problem validating your input, please check them and resubmit"
      );
    } else {
      const validatedMemberData = {
        name,
        funFact,
      };
      console.log(validatedMemberData);
      props.onSubmit(validatedMemberData);
      history.push("/introduction");
    }
  };

  return (
    <>
      <TextField
        error={error && name === ""}
        value={name}
        id="name-input"
        label="Name"
        onChange={(event) => setName(event.target.value)}
        {...commonProps}
      />
      <TextField
        error={error && funFact === ""}
        value={funFact}
        id="funFact-input"
        label="Fun fact"
        onChange={(event) => setFunFact(event.target.value)}
        {...commonProps}
      />
      <Button
        variant="contained"
        color="primary"
        style={{ width: "100%" }}
        onClick={onSubmit}
      >
        Submit
      </Button>
    </>
  );
}

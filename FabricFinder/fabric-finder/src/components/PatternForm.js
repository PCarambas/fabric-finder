import { useState, useEffect } from 'react';
import { Button, Form, FormGroup, Input, Label } from "reactstrap"
import { useNavigate } from 'react-router-dom';
import { addPattern } from '../modules/patternManager';





export default function FabricForm() {

    const navigate = useNavigate();
    const [userInput, setUserInput] = useState({
        name: '',
        imageUrl: '',
        userProfileId: 0,
    });

    const handleUserInput = (event) => {
        const copy = { ...userInput };
        copy[event.target.name] = event.target.value;
        setUserInput(copy);
    };


    const handleSavePattern = (event) => {
        event.preventDefault();
        return addPattern(userInput)
            .then(() => {
                navigate("/");
            })
            .catch((err) => alert(`An error ocurred: ${err.message}`));
    };
    return (
        <Form onSubmit={handleSavePattern}>
            <FormGroup>
                <Label for="newPattern">New Pattern</Label>
            </FormGroup>
            <FormGroup>
                <Label for="name">Name</Label>
                <Input id="name"
                    name="name"
                    type="text"
                    onChange={handleUserInput} />
            </FormGroup>
            <FormGroup>
                <Label for="imageUrl">Image Url</Label>
                <Input id="imageUrl"
                    name="imageUrl"
                    type="text"
                    onChange={handleUserInput} />
            </FormGroup>
            <Button onClick={(clickEvent) => handleSavePattern(clickEvent)}>Add New Pattern</Button>
        </Form>
    );
}









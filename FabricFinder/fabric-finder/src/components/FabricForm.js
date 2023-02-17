import { useState, useEffect } from 'react';
import { addFabric, addPatternFabric } from '../modules/fabricManager';
import { Button, Form, FormGroup, Input, Label } from "reactstrap"
import { useNavigate } from 'react-router-dom';
import { getFabricTypes } from '../modules/fabricTypeManager';
import { getPatterns, getPattern } from '../modules/patternManager';






export default function FabricForm() {
    const navigate = useNavigate();
    const [fabricTypes, setFabricTypes] = useState([]);
    const [patterns, setPatterns] = useState([]);
    const [userInput, setUserInput] = useState({
        name: '',
        color: '',
        yardage: 0,
        imageUrl: '',
        userId: 0,
        fabricTypeId: 0,
        patterns: [],



    });

    const [selectedOptions, setSelectedOptions] = useState([]);

    useEffect(() => {
        getFabricTypes().then((fabricType) => {
            setFabricTypes(fabricType)
        });
    }, []);

    useEffect(() => {
        getPatterns().then((pattern) => {
            setPatterns(pattern)
        });
    }, []);

    const handleUserInput = (event) => {
        const copy = { ...userInput };
        copy[event.target.name] = event.target.value;
        setUserInput(copy);
    };

    const handleUserFabricType = (event) => {
        const copy = { ...userInput };
        copy[event.target.name] = event.target.value;
        setUserInput(copy);
    };

    const handleUserInputSelect = (event) => {
        const newSelectedOptions = [];
        for (let i = 0; i < event.target.selectedOptions.length; i++) {
            newSelectedOptions.push(parseInt(event.target.selectedOptions[i].value));

        }
        setSelectedOptions(newSelectedOptions);
    };

    const handleSaveFabric = (event) => {
        event.preventDefault();





        addFabric(userInput)
            .then((f) => {

                const promises = []
                selectedOptions.forEach(p => {
                    const newPatternFabric = {

                        fabricId: f.id,
                        patternId: p
                    };
                    promises.push(addPatternFabric(newPatternFabric));
                });
                return Promise.all(promises)
            }).then(() => {
                navigate("/");
            })
            .catch((err) => alert(`An error ocurred: ${err.message}`));
    };

    return (
        <Form onSubmit={handleSaveFabric}>
            <FormGroup>
                <Label for="newFabric">New Fabric</Label>
            </FormGroup>
            <FormGroup>
                <Label for="name">Name</Label>
                <Input id="name"
                    name="name"
                    type="text"
                    onChange={handleUserInput} />
            </FormGroup>
            <FormGroup>
                <Label for="color">Color</Label>
                <Input
                    id="color"
                    name="color"
                    type="text"
                    onChange={handleUserInput} />
            </FormGroup>
            <FormGroup>
                <Label for="yardage">Yardage</Label>
                <Input id="yardage"
                    name="yardage"
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
            <FormGroup>
                <Label for="fabricTypeId">Fabric Type</Label><br></br>
                <select
                    required
                    id="fabricTypeId"
                    name="fabricTypeId"
                    onChange={handleUserInput}
                >
                    <option value={0}>Select a Fabric Type</option>
                    {fabricTypes.map((fabricType) => {
                        return (
                            <option key={fabricType.id} value={fabricType.id}>
                                {fabricType.type}
                            </option>
                        );
                    })}
                </select>
            </FormGroup>
            <select
                multiple
                onChange={handleUserInputSelect}
                value={selectedOptions}
            >
                {patterns.map((pattern) => {
                    return (
                        <option key={pattern.id} value={pattern.id}>
                            {pattern.name}
                        </option>
                    );
                })}
            </select>
            <FormGroup>

            </FormGroup>
            <Button onClick={(clickEvent) => handleSaveFabric(clickEvent)}>Add New Fabric</Button>
        </Form>
    );
}








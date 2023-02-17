import { useState, useEffect } from "react"
import { useNavigate, useParams } from "react-router-dom";
import { Button, Form, FormGroup, Input, Label } from "reactstrap"
import "firebase/auth";
import { getFabric, updateFabric } from "../modules/fabricManager";
import { getFabricTypes } from "../modules/fabricTypeManager";

export const EditFabric = () => {


    const emptyFabric = {
        id: 0,
        name: "",
        color: "",
        yardage: "",
        imageUrl: "",
        fabricTypeId: 0

    };
    const [fabricSelect, update] = useState({});
    const [fabricTypes, setFabricTypes] = useState([]);


    const { fabricId } = useParams();
    const navigate = useNavigate();

    useEffect(() => {
        getFabric(fabricId).then((fabric) => update(fabric));
    }, []);

    useEffect(() => {
        getFabricTypes().then((fabricType) => setFabricTypes(fabricType));
    }, []);

    //Being sent to API
    const handleSaveFabric = (event) => {
        event.preventDefault()
        const fabricToSendToAPI = {
            id: fabricSelect.id,
            name: fabricSelect.name,
            color: fabricSelect.color,
            yardage: fabricSelect.yardage,
            imageUrl: fabricSelect.imageUrl,
            fabricTypeId: fabricSelect.fabricTypeId,

        }

        return updateFabric(fabricSelect.id, fabricToSendToAPI)
            .then(() => {
                navigate(`/`)
            })
    }

    const handleUserInput = (event) => {
        const copy = { ...fabricSelect };
        copy[event.target.name] = event.target.value;
        update(copy);
    };

    const handleUserInputSelect = (event) => {
        const copy = { ...fabricSelect };
        copy[event.target.id] = parseInt(event.target.value);
        update(copy);
    };

    return (
        <Form onSubmit={handleSaveFabric}>
            <FormGroup>
                <Label for="newFabric">Edit My Fabric</Label>
            </FormGroup>
            <FormGroup>
                <Label for="name">Name</Label>
                <Input id="name"
                    name="name"
                    type="text"
                    value={fabricSelect.name}
                    onChange={handleUserInput} />
            </FormGroup>
            <FormGroup>
                <Label for="color">Color</Label>
                <Input
                    id="color"
                    name="color"
                    type="text"
                    value={fabricSelect.color}
                    onChange={handleUserInput} />
            </FormGroup>
            <FormGroup>
                <Label for="yardage">Yardage</Label>
                <Input id="yardage"
                    name="yardage"
                    type="text"
                    value={fabricSelect.yardage}
                    onChange={handleUserInput} />
            </FormGroup>
            <FormGroup>
                <Label for="imageUrl">Image Url</Label>
                <Input id="imageUrl"
                    name="imageUrl"
                    type="text"
                    value={fabricSelect.imageUrl}
                    onChange={handleUserInput} />
            </FormGroup>
            <FormGroup>
                <Label for="fabricTypeId">Fabric Type</Label><br></br>
                <select
                    required
                    id="fabricTypeId"
                    name="fabricTypeId"
                    value={fabricSelect.fabricTypeId}
                    onChange={handleUserInputSelect}
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
            <Button onClick={(clickEvent) => handleSaveFabric(clickEvent)}>Update My Fabric</Button>
        </Form>
    );
}
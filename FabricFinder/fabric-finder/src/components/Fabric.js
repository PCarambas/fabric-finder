
import { Card, CardBody, CardTitle, CardText, CardSubtitle, Button } from 'reactstrap';
import { useNavigate } from 'react-router-dom';
import { deleteFabric } from '../modules/fabricManager';



export default function Fabric({ fabric, getAllFabrics }) {
    const navigate = useNavigate();

    const handleDelete = (evt, fabricId) => {
        evt.preventDefault();
        deleteFabric(fabricId).then(getAllFabrics);

    }

    return (
        <Card >
            <Card
                color="dark"
                outline
                style={{ marginBottom: '4px' }}
            >
                <CardBody>
                    <CardTitle tag="h3">
                        Fabric Type
                    </CardTitle>
                    <CardTitle tag="h4">
                        {fabric.name}
                    </CardTitle><br></br>
                    <div>
                        <strong><img src={fabric.imageUrl} /></strong>
                    </div><br></br>
                    <CardSubtitle>
                        Color: {fabric.color}
                    </CardSubtitle><br></br>
                    <CardText>
                        Yardage: {fabric.yardage}
                    </CardText>
                    <CardText>
                        Fabric Type: {fabric?.fabricType?.type}
                    </CardText>
                    <ul>
                        {fabric?.patterns?.map(p =>
                        (
                            <li key={p.id}>{p.name}</li>
                        ))}
                    </ul>
                    <div>
                        <Button
                            color="secondary"
                            onClick={() => navigate(`/updatefabric/${fabric.id}`)}
                        >
                            Edit Fabric
                        </Button>
                    </div><br></br>
                    <div>
                        {/* stretch goal <Button
                            color="secondary"
                            onClick={() => navigate(`/addpattern/`)}
                        >
                            Add A Pattern
                        </Button> */}
                    </div>
                    <div>
                        <Button
                            color="outline-danger"
                            onClick={(event) => handleDelete(event, fabric.id)}
                        >
                            Delete Fabric
                        </Button>
                    </div>

                </CardBody>
            </Card>
        </Card>
    );
};

















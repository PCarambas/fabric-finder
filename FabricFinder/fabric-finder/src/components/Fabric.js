
import { Card, CardBody, CardTitle, CardText, CardSubtitle, Button } from 'reactstrap';

export default function Fabric({ fabric }) {
    return (
        <Card >
            <Card
                color="dark"
                outline
                style={{ marginBottom: '4px' }}
            >
                <CardBody>
                    <CardTitle tag="h5">
                        Name: {fabric.name}
                    </CardTitle>
                    {<div>
                        <strong><img src={fabric.imageUrl} /></strong>
                    </div>}
                    <CardSubtitle
                        className="mb-2 text-muted"
                        tag="h6"
                    >
                        Color: {fabric.color}
                    </CardSubtitle>
                    <CardText>
                        Yardage: {fabric.yardage}
                    </CardText>
                    {/* <Button color="dark" onClick={() => {
                        setDetailsFabricId(fabric.id);
                        window.scrollTo({
                            top: 0,
                            left: 0,
                            behavior: 'smooth'
                        });
                    }}>
                        Show Details
                    </Button> */}
                </CardBody>
            </Card>
        </Card>
    );
};












import {Component} from "react";
import { saveAs, createBlob } from 'file-saver';

export class Image extends Component{
    constructor(props) {
        super(props);
        this.state={
            isOpen : false,
            path: './src/component/Images/photo_2023-03-26_03-19-49.jpg',
            AllData: this.props.item.props.photoData,
            mainPhoto: "",
            dialogPhoto: ""
        }
        this.state.mainPhoto = 'data:image/png;base64,'.concat(this.state.AllData.photoForAll);
        this.state.dialogPhoto = 'data:image/png;base64,'.concat(this.state.AllData.photoForAll);
        //document.getElementsByClassName("small").src = 'data:image/png;base64,'.concat(this.state.AllData.photoForOwner)
    }
    handleShowDialog = () => {
        let owner = localStorage.getItem('jwt');
        owner = JSON.parse(owner);
        owner =  owner.login;
        if(owner===this.state.AllData.owner)
        {
            this.setState({dialogPhoto: 'data:image/png;base64,'.concat(this.state.AllData.photoForOwner)})
        }
        this.setState({ isOpen: !this.state.isOpen });
        console.log("clicked");
    };
    saveImage = () => {
        let dataURI = this.state.dialogPhoto;
        const byteString = atob(dataURI.split(',')[1]);

        // separate out the mime component
        const mimeString = dataURI.split(',')[0].split(':')[1].split(';')[0];

        // write the bytes of the string to an ArrayBuffer
        const ab = new ArrayBuffer(byteString.length);

        // create a view into the buffer
        const ia = new Uint8Array(ab);

        // set the bytes of the buffer to the correct values
        for (let i = 0; i < byteString.length; i++) {
            ia[i] = byteString.charCodeAt(i);
        }

        // write the ArrayBuffer to a blob, and you're done
        const blob = new Blob([ab], {type: mimeString});
        saveAs(blob, "saved.png");
    }
    render() {
        return(
            <div className={'Image'}>
                <img
                    className="small"
                    src={this.state.mainPhoto}
                    onClick={this.handleShowDialog}
                    alt="no image"
                />
                {this.state.isOpen && (
                    <dialog
                        className="dialog"
                        style={{position: "fixed",
                            top: "50%",
                            left: "50%",
                            background: "#507799",
                            transform: "translate(-50%, -50%)",
                            "border-radius": "4px",
                            width: "50%",}}
                        open
                        onClick={this.handleShowDialog}
                    >
                        <h1>User : {this.state.AllData.owner}</h1>
                        <img
                            className="image"
                            src={this.state.dialogPhoto}
                            onClick={this.handleShowDialog}
                         alt={"small image"}/>
                        <h1>{this.state.AllData.subscript}</h1>
                        <button className="ButSave"
                                onClick={() => this.saveImage()}>Save</button>
                        </dialog>
                )}

            </div>
        )
    }
}
export default Image
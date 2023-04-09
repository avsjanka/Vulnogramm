import {Component} from "react";
import Image from "./ImageDialog";

export class Table extends Component{
    render() {
        return(
            <main>
                {this.props.Table.map(el =>(<Image key={el.id} item={el} />))}
            </main>
        )
    }
}
export default Table
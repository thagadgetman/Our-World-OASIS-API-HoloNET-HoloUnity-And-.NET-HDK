import React, { Component } from 'react';
import { Modal } from "react-bootstrap";
import '../../../../assets/scss/coming-soon.scss';
import InfoIcon from '../../../../assets/images/icon-info.svg'

class ViewMission extends Component {
    state = {  } 
    render() { 
        const { show, hide } = this.props;

        return (
            <>
                <Modal
                    size="sm"
                    show={show}
                    dialogClassName="modal-90w"
                    onHide={() => hide('mission', 'viewMission')}
                >
                    <Modal.Body className="text-center coming-soon">
                        <img
                            src={InfoIcon}
                            alt="icon"
                        />
                        <h2>Coming Soon</h2>
                        <p>This module is coming soon...</p>
                        <button onClick={() => hide('mission', 'viewMission')}>OK</button>
                    </Modal.Body>
                </Modal>
            </>
        );
    }
}
 
export default ViewMission;
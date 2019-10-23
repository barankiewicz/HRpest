import React, { Component } from 'react';
import { Row, Col } from 'antd';
import { Input } from 'antd';
import { Typography } from 'antd';
import 'antd/dist/antd.css';
const { Title } = Typography;
export class Login extends Component {

  render () {
    return (
      <div>
        <Row type="flex" justify="space-around" align="middle">
          <Col span={4} offset={10}>
            <Title>HRpest</Title>
          </Col>
        </Row>
        <Row type="flex" justify="space-around" align="middle">
          <Col span={4} offset={10}>
            <Input placeholder="Username" />
            <Input.Password placeholder="Password" />
          </Col>
        </Row>
    </div>
    );
  }
}
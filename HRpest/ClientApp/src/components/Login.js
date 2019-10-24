import React, { Component } from 'react'
import { Form, Icon, Input, Button, Checkbox, Row, Typography } from 'antd';
import './Login.css';

const { Title } = Typography;

class NormalLoginForm extends React.Component {
  handleSubmit = e => {
    e.preventDefault();
    this.props.form.validateFields((err, values) => {
      if (!err) {
        console.log('Received values of form: ', values);
      }
    });
  };

  render() {
    const { getFieldDecorator } = this.props.form;
    return (
      <div id = "center">
        <Row type="flex" justify="space-around" align="middle"><Title strong>HRpest</Title></Row>
      <Row type="flex" justify="space-around" align="middle">
        <Form onSubmit={this.handleSubmit} className="login-form" >
          <Form.Item>
            {getFieldDecorator('username', {
              rules: [{ required: true, message: 'Please input your username!' }
                      ],
            })(
              <Input
                prefix={<Icon type="user" style={{ color: 'rgba(0,0,0,.25)' }} />}
                placeholder="Username"
              />,
            )}
          </Form.Item>
          <Form.Item>
            {getFieldDecorator('password', {
              rules: [{ required: true, message: 'Please input your Password!' },
                  { min: 6, message: 'Your username must be at least 8 characters long!' }],
            })(
              <Input
                prefix={<Icon type="lock" style={{ color: 'rgba(0,0,0,.25)' }} />}
                type="password"
                placeholder="Password"
              />,
            )}
          </Form.Item>
          <Form.Item>
            {getFieldDecorator('remember', {
              valuePropName: 'checked',
              initialValue: true,
            })(<Checkbox>Remember me</Checkbox>)}
            <a className="login-form-forgot" href="">
              Forgot password
          </a>
            <Button type="primary" htmlType="submit" className="login-form-button">
              Log in
          </Button>
            Or <a href="">register now!</a>
          </Form.Item>
        </Form>
      </Row>
      </div>
    );
  }
}

const WrappedNormalLoginForm = Form.create({ name: 'normal_login' })(NormalLoginForm);
export default WrappedNormalLoginForm;

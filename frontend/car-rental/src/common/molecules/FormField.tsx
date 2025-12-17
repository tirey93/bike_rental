import React, { ChangeEvent } from 'react';
import styled from 'styled-components';
import { Label } from '../atoms/Label';
import { Input } from '../atoms/Input';
import PropTypes from 'prop-types';

interface FormFieldProps {
  onChange?: (e: ChangeEvent<HTMLInputElement | HTMLTextAreaElement>) => void;
  value?: string;
  label: string;
  name: string;
  id: string;
  type?: 'text' | 'email' | 'password' | 'number' | 'tel' | 'url' | 'search' | 'date';
  isTextarea?: boolean;
  placeholder?: string;
  required?: boolean;
  disabled?: boolean;
}

const Wrapper = styled.div`
  display: flex;
  flex-direction: column;
  align-items: flex-start;

  ${Label} {
    margin: 10px 0;
  }
`;

const FormField =  React.forwardRef<
  HTMLInputElement | HTMLTextAreaElement,
  FormFieldProps>(({ onChange, value, label, name, id, type = 'text', isTextarea, ...props }, ref) => {
  return (
    <Wrapper>
      <Label htmlFor={id}>{label}</Label>
      {isTextarea ? (
        <Input isTextarea as="textarea" name={name} id={id} value={value} onChange={onChange} data-testid={label} {...props} ref={ref as React.Ref<HTMLTextAreaElement>} />
      ) : (
        <Input name={name} id={id} type={type} value={value} onChange={onChange} data-testid={label} {...props} ref={ref as React.Ref<HTMLInputElement>}  />
      )}
    </Wrapper>
  );
});

FormField.prototype = {
  label: PropTypes.string.isRequired,
  name: PropTypes.string.isRequired,
  id: PropTypes.string.isRequired,
  type: PropTypes.string,
};

export default FormField;
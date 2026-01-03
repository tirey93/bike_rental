import styled from "styled-components";

interface ConfirmationButtonWrapperProps {
  $important?: boolean;
}
export const ConfirmationButtonWrapper = styled.div<ConfirmationButtonWrapperProps>`
  display: flex;
  flex-direction: row;
  justify-content: flex-end;
  align-items: center;
  gap: 12px;
  width: 80%;

  > button {
    background-color: ${props => props.$important ? 'darkred' : 'defaultColor'};
    margin-top: 36px;
    padding: 8px 24px;
  }
`;